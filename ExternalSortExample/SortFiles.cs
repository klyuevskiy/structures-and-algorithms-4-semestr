using ExternalSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSortExample
{
    class SortFiles
    {
        private readonly int elementsNumber;
        private readonly int elementsNumberIndex;
        private readonly SortInformationPrinter sortInformationPrinter;

        SortFile sortedFile,
            randomFile,
            inverseFile;

        public SortFiles(int elementsNumber, int elementsNumberIndex, SortInformationPrinter sortInformationPrinter)
        {
            this.elementsNumber = elementsNumber;
            this.elementsNumberIndex = elementsNumberIndex;
            this.sortInformationPrinter = sortInformationPrinter;
        }

        SortInformation SortFile(SortFile file)
        {
            NaturalMultipathMerging Sort = new NaturalMultipathMerging((int)Math.Log2(elementsNumber) + 1);
            return Sort.Sort(file);
        }

        void SortSortedFile()
        {
            sortedFile = FileGenerator.GenerateSortedFile(elementsNumber);

            SortInformation sortInformation = SortFile(sortedFile);

            sortedFile.Delete();

            sortInformationPrinter.PrintSortedFileSortInformation(elementsNumberIndex, sortInformation);
        }

        void SortRandomFile()
        {
            randomFile = FileGenerator.GenerateRandomFile(elementsNumber);

            SortInformation sortInformation = SortFile(randomFile);

            randomFile.Delete();
            sortInformationPrinter.PrintRandomFileSortInformation(elementsNumberIndex, sortInformation);
        }

        void SortInverseFile()
        {
            inverseFile = FileGenerator.GenerateInverseFile(elementsNumber);

            SortInformation sortInformation = SortFile(inverseFile);
            inverseFile.Delete();

            sortInformationPrinter.PrintInverseFileSortInformation(elementsNumberIndex, sortInformation);
        }

        public Task[] Start()
        {
            return new Task[]
            {
                Task.Run(SortSortedFile),
                Task.Run(SortRandomFile),
                Task.Run(SortInverseFile)
            };
        }
    }
}
