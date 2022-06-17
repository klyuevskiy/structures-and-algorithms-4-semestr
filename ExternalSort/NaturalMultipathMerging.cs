using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExternalSort
{
    public class NaturalMultipathMerging
    {
        readonly int _filesNumber;
        BinaryFile[] _files;

        DoublyLinkedList _currentSorting,
            _nextSorting;

        SortInformation information;

        BinaryFile sortedFile;

        public NaturalMultipathMerging(int filesNumber)
        {
            _filesNumber = filesNumber;

            if (filesNumber < 2)
                _filesNumber = 10;

            _files = new BinaryFile[filesNumber];

            _currentSorting = new DoublyLinkedList();
            _nextSorting = new DoublyLinkedList();

            sortedFile = null;
        }

        void StartReadFiles()
        {
            foreach (var item in _files)
            {
                item.StartRead();
            }
        }

        void StartWriteFiles()
        {
            foreach (var item in _files)
            {
                item.StartWrite();
            }
        }

        void CreateFiles()
        {
            for (int i = 0; i < _filesNumber; i++)
                _files[i] = new BinaryFile();
        }

        void DeleteFiles()
        {
            foreach (var item in _files)
            {
                item.Delete();
            }
        }

        bool Split()
        {
            sortedFile.StartRead();
            StartWriteFiles();

            // если он пустой, то конец

            if (sortedFile.EndOfFile)
                return false;

            int previousNumber = sortedFile.Read(),
                seriesIndex = 0;

            _files[seriesIndex].Write(previousNumber);

            while (!sortedFile.EndOfFile)
            {
                int number = sortedFile.Read();

                if (number < previousNumber)
                    seriesIndex++;

                information.ComparesNumber++;

                _files[seriesIndex % _filesNumber].Write(number);
                previousNumber = number;
            }

            return seriesIndex != 0;
        }

        // возвращает true если надо продолжать сортировать
        void Merge()
        {
            sortedFile.StartWrite();
            StartReadFiles();

            // считываем вначачале с каждого файла по одному числу и добавляем в структуру

            for (int i = 0; i < _filesNumber && !_files[i].EndOfFile; i++)
            {
                int number = _files[i].Read();
                _currentSorting.Add(number, i);
            }

            // далее пока структуры не пусты, мы объединяем
            while (!_currentSorting.IsEmpty() || !_nextSorting.IsEmpty())
            {
                // пока в текущей структуре есть числа, то идёт текущая серия
                while (!_currentSorting.IsEmpty())
                {
                    int number, fileIndex;
                    (number, fileIndex) = _currentSorting.GetMin();

                    // записываем в исходный файл новое значение
                    sortedFile.Write(number);

                    // считаем из файла новое значение
                    if (!_files[fileIndex].EndOfFile)
                    {
                        int nextNumber = _files[fileIndex].Read();

                        // если текущая серия, то записываем в текущую структуру
                        // если новая серия то в новую

                        information.ComparesNumber++;

                        if (nextNumber >= number)
                            _currentSorting.Add(nextNumber, fileIndex);
                        else
                            _nextSorting.Add(nextNumber, fileIndex);
                    }
                }

                // меняем местами сортирующие структуры
                DoublyLinkedList tmp = _currentSorting;
                _currentSorting = _nextSorting;
                _nextSorting = tmp;
            }
        }

        public SortInformation Sort(BinaryFile file)
        {
            information = new SortInformation();

            // в любом случае будет один Split для проверки, ог должен учитываться как проход
            information.PassesNumber = 1;
            sortedFile = file;

            information.ElapsedTime.Start();

            CreateFiles();

            while (Split())
            {
                Merge();
                information.PassesNumber++;
            }

            DeleteFiles();

            information.ElapsedTime.Stop();
            
            information.ComparesNumber +=
                _currentSorting.ComparesNumber + _nextSorting.ComparesNumber;

            return information;
        }
    }
}
