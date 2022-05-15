using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSort
{
    public class NaturalMultipathMerging : IExternalSort
    {
        private readonly int _filesNumber;
        private SortFile[] _files;
        ISortingStructure currentSorting,
            nextSorting;

        public NaturalMultipathMerging(int filesNumber = 10)
        {
            _filesNumber = filesNumber;

            if (filesNumber < 2)
                _filesNumber = 10;

            _files = new SortFile[filesNumber];

            for (int i = 0; i < filesNumber; i++)
                _files[i] = new SortFile();

            currentSorting = new ListSorting();
            nextSorting = new ListSorting();
        }

        void OpenFilesToRead()
        {
            foreach (var item in _files)
            {
                item.OpenToRead();
            }
        }

        void OpenFilesToWrite()
        {
            foreach (var item in _files)
            {
                item.OpenToWrite();
            }
        }

        void DeleteFiles()
        {
            foreach (var item in _files)
            {
                item.Delete();
            }
        }

        void Split(SortFile file)
        {
            file.OpenToRead();
            OpenFilesToWrite();

            // если он пустой, то конец

            if (file.EndOfFile)
                return;

            int previousNumber = file.Read(),
                seriesIndex = 0;

            _files[seriesIndex].Write(previousNumber);

            while (!file.EndOfFile)
            {
                int number = file.Read();

                if (number < previousNumber)
                    seriesIndex++;

                _files[seriesIndex % _filesNumber].Write(number);
                previousNumber = number;
            }
        }

        // возвращает true если надо продолжать сортировать
        bool Merge(SortFile file)
        {
            file.OpenToWrite();
            OpenFilesToRead();

            // считываем вначачале с каждого файла по одному числу и добавляем в структуру

            for (int i = 0; i < _filesNumber; i++)
            {
                if (!_files[i].EndOfFile)
                {
                    int number = _files[i].Read();
                    currentSorting.Add(number, i);
                }
            }

            // если ни разу не добавляли в следующую структуру
            // то в каждом файле не более одной серии, тогда в конце получится отсортированный файл
            bool IsAddToNextSorting = false;

            // далее пока структуры не пусты, мы объединяем
            while (!currentSorting.IsEmpty() || !nextSorting.IsEmpty())
            {
                // пока в текущей структуре есть числа, то идёт текущая серия
                while (!currentSorting.IsEmpty())
                {
                    int number, fileIndex;
                    (number, fileIndex) = currentSorting.GetMin();

                    // записываем в исходный файл новое значение
                    file.Write(number);

                    // считаем из файла новое значение
                    if (!_files[fileIndex].EndOfFile)
                    {
                        int nextNumber = _files[fileIndex].Read();

                        // если текущая серия, то записываем в текущую структуру
                        // если новая серия то в новую

                        if (nextNumber >= number)
                            currentSorting.Add(nextNumber, fileIndex);
                        else
                        {
                            nextSorting.Add(nextNumber, fileIndex);
                            IsAddToNextSorting = true;
                        }
                    }
                }

                // меняем местами сортирующие структуры
                ISortingStructure tmp = currentSorting;
                currentSorting = nextSorting;
                nextSorting = tmp;
            }

            return IsAddToNextSorting;
        }

        public void Sort(SortFile file)
        {
            do
            {
                Split(file);
            }
            while (Merge(file));
        }
    }
}
