using ExternalSort;
using System;

namespace ExternalSortExample
{
    static class FileGenerator
    {
        interface IGenerator
        {
            int Generate();
        }

        class SortGenerator : IGenerator
        {
            int i;
            public SortGenerator() => i = 0;
            public int Generate() => i++;
        }

        class RandomGenerator : IGenerator
        {
            int elementsNumber;
            Random random;

            public RandomGenerator(int elementsNumber)
            {
                this.elementsNumber = elementsNumber;
                random = new Random();
            }

            public int Generate() => random.Next(elementsNumber);

        }

        class InverseGenerator : IGenerator
        {
            int elementsNumber;

            public InverseGenerator(int elementsNumber) =>
                this.elementsNumber = elementsNumber;

            public int Generate() => elementsNumber--;

        }

        static BinaryFile GenerateFile(int elementsNumber, IGenerator generator)
        {
            BinaryFile file = new BinaryFile();

            file.StartWrite();

            for (int i = 0; i < elementsNumber; i++)
                file.Write(generator.Generate());

            return file;
        }

        public static BinaryFile GenerateSortedFile(int elementsNumber) =>
            GenerateFile(elementsNumber, new SortGenerator());

        public static BinaryFile GenerateRandomFile(int elementsNumber) =>
            GenerateFile(elementsNumber, new RandomGenerator(elementsNumber));

        public static BinaryFile GenerateInverseFile(int elementsNumber) =>
            GenerateFile(elementsNumber, new InverseGenerator(elementsNumber));
    }
}
