using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSort
{
    public interface IFile
    {
        bool EndOfFile { get; }

        void OpenToRead();
        void OpenToWrite();

        int Read();
        void Write(int number);

        void Delete();
    }
}
