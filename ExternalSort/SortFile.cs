using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExternalSort
{
    public class SortFile
    {
        //private readonly string _filePath;
        //private StreamWriter writer;
        //private StreamReader reader;

        //public bool EndOfFile { get; private set; }
        //public bool EndOfSeries { get; set; }

        //public SortFile()
        //{
        //    _filePath = Guid.NewGuid().ToString() + ".txt";
        //}

        //public SortFile(string filePath)
        //{
        //    _filePath = filePath;
        //}

        //public void Remove()
        //{
        //    writer?.Close();
        //    reader?.Close();

        //    //File.Delete(_filePath);
        //}

        //public void OpenToWrite()
        //{
        //    reader?.Close();
        //    writer = new StreamWriter(_filePath);
        //    EndOfFile = false;
        //}

        //public void OpenToRead()
        //{
        //    writer?.Close();
        //    reader = new StreamReader(_filePath);
        //    EndOfFile = false;
        //}

        //public void Write(int number)
        //{
        //    writer.Write(number.ToString() + " ");
        //}

        //public int Read()
        //{
        //    string res = "";

        //    int c = reader.Read();

        //    // читаем до пробела
        //    while (c != -1 && (char)c !=' ')
        //    {
        //        res += (char)c;
        //        c = reader.Read();
        //    }

        //    if (c == -1)
        //        EndOfFile = true;

        //    return Int32.Parse(res);
        //}

        private readonly string _filePath;
        private FileStream _file;
        private long _numbersNumber;
        public bool EndOfFile { get; private set; }

        public SortFile()
        {
            // генерируем уникальное имя файла
            _filePath = Guid.NewGuid().ToString();

            // создадим файл
            _file = new FileStream(_filePath, FileMode.Create);
        }

        public SortFile(string filePath)
        {
            _filePath = filePath;
            _file = new FileStream(_filePath, FileMode.OpenOrCreate);
        }

        public void OpenToRead()
        {
            _file.Close();
            _file = new FileStream(_filePath, FileMode.Open);
            _numbersNumber = _file.Length / sizeof(int);
            EndOfFile = _numbersNumber == 0;
        }

        public void OpenToWrite()
        {
            _file.Close();
            _file = new FileStream(_filePath, FileMode.Truncate);
            EndOfFile = false;
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
        }

        public void Delete()
        {
            _file = null;
            File.Delete(_filePath);
        }
    }
}
