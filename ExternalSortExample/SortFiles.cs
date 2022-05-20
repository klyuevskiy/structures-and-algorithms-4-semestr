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
        private readonly Type sortingStructureType;
        private readonly int elementsNumber;
        private readonly int elementsNumberIndex;
        private readonly SortInformationPrinter sortInformationPrinter;

        IFile sortedFile,
            randomFile,
            inverseFile;

        public SortFiles(Type sortingStructureType, int elementsNumber, int elementsNumberIndex, SortInformationPrinter sortInformationPrinter)
        {
            this.sortingStructureType = sortingStructureType;
            this.elementsNumber = elementsNumber;
            this.elementsNumberIndex = elementsNumberIndex;
            this.sortInformationPrinter = sortInformationPrinter;
        }

        SortInformation SortFile(IFile file)
        {
            NaturalMultipathMerging Sort = new NaturalMultipathMerging(sortingStructureType, (int)Math.Log2(elementsNumber) + 1);
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

        public void Start()
        {
            SortSortedFile();
            SortRandomFile();
            SortInverseFile();
        }
    }
}
