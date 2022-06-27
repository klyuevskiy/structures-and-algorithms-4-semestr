using ExternalSort;
using System.IO;

namespace ExternalSortExample
{
    class SortFiles
    {
        private readonly int elementsNumber;
        private readonly int elementsNumberIndex;
        private readonly SortInformationPrinter sortInformationPrinter;
        private readonly int filesNumber;

        BinaryFile sortedFile,
            randomFile,
            inverseFile;

        public SortFiles(int elementsNumber, int rowIndex,
            SortInformationPrinter sortInformationPrinter, int filesNumber)
        {
            this.elementsNumber = elementsNumber;
            this.elementsNumberIndex = rowIndex;
            this.sortInformationPrinter = sortInformationPrinter;
            this.filesNumber = filesNumber;
        }

        void SortSortedFile()
        {
            sortedFile = FileGenerator.GenerateSortedFile(elementsNumber);

            SortInformation sortInformation = new
                NaturalMultipathMerging(filesNumber).Sort(sortedFile);

            BinToTxt(sortedFile, $"Sorted{elementsNumber}.txt");

            sortedFile.Delete();

            sortInformationPrinter.PrintSortedFileInformation(elementsNumberIndex, sortInformation);
        }

        void SortRandomFile()
        {
            randomFile = FileGenerator.GenerateRandomFile(elementsNumber);

            SortInformation sortInformation = new
                NaturalMultipathMerging(filesNumber).Sort(randomFile);

            BinToTxt(randomFile, $"Random{elementsNumber}.txt");

            randomFile.Delete();
            sortInformationPrinter.PrintRandomFileInformation(elementsNumberIndex, sortInformation);
        }

        void SortInverseFile()
        {
            inverseFile = FileGenerator.GenerateInverseFile(elementsNumber);

            SortInformation sortInformation = new
                NaturalMultipathMerging(filesNumber).Sort(inverseFile);

            BinToTxt(inverseFile, $"Inverse{elementsNumber}.txt");

            inverseFile.Delete();

            sortInformationPrinter.PrintInverseFileInformation(elementsNumberIndex, sortInformation);
        }

        void BinToTxt(BinaryFile file, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            file.StartRead();

            while (!file.EndOfFile)
                writer.WriteLine(file.Read());

            writer.Close();
        }

        public void Start()
        {
            SortSortedFile();
            SortRandomFile();
            SortInverseFile();
        }
    }
}
