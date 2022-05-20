using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExternalSort
{
    public class BinaryFile : IFile
    {
        private readonly string _filePath;
        private FileStream _file;
        private long _numbersNumber;
        public bool EndOfFile { get; private set; }

        public BinaryFile()
        {
            // генерируем уникальное имя файла
            _filePath = Guid.NewGuid().ToString();

            // создадим файл
            _file = new FileStream(_filePath, FileMode.Create);

            _numbersNumber = 0;
            EndOfFile = true;
        }

        public BinaryFile(string filePath)
        {
            _filePath = filePath;
            _file = new FileStream(_filePath, FileMode.OpenOrCreate);

            _numbersNumber = _file.Length / sizeof(int);
            EndOfFile = _numbersNumber == 0;
        }

        public void OpenToRead()
        {
            _file.Seek(0, SeekOrigin.Begin);

            EndOfFile = _numbersNumber == 0;
            //_file.Close();
            //_file = new FileStream(_filePath, FileMode.Open);
            //_numbersNumber = _file.Length / sizeof(int);
            //EndOfFile = _numbersNumber == 0;
        }

        public void OpenToWrite()
        {
            _file.Seek(0, SeekOrigin.Begin);
            _numbersNumber = 0;
            //_file.Close();
            //_file = new FileStream(_filePath, FileMode.Truncate);
            //EndOfFile = false;
        }

        public int Read()
        {
            if (_numbersNumber > 0)
            {
                byte[] buffer = new byte[sizeof(int)];
                _file.Read(buffer);

                _numbersNumber--;

                if (_numbersNumber <= 0)
                    EndOfFile = true;

                return BitConverter.ToInt32(buffer);
            }

            return -1;
        }

        public void Write(int number)
        {
            _file.Write(BitConverter.GetBytes(number), 0, sizeof(int));
            _numbersNumber++;
        }

        public void Delete()
        {
            _file?.Close();
            _file = null;
            File.Delete(_filePath);
        }
    }
}
