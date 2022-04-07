using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Hash
{
    [Serializable]
    public class Car
    {
        string defaultCarNumber = "А111АА";
        string defaultBrand = "", defaultFIO = "";

        private string carNumber;
        public string CarNumber
        {
            get => carNumber;
            set
            {
                if (value == null || !Regex.IsMatch(value, @"^[А-Я]{1}\d{3}[А-Я]{2}$"))
                    throw new ArgumentException("Не правильный формат номера машины");
                carNumber = value;
            }
        }

        public string Brand { get; set; }
        public string FIO { get; set; }

        public Car()
        {
            CarNumber = defaultCarNumber;
            Brand = defaultBrand;
            FIO = defaultFIO;
        }

        public override string ToString()
        {
            return CarNumber;
        }

        public Car(string carNumber, string brand, string FIO)
        {
            this.CarNumber = carNumber;
            this.Brand = brand;
            this.FIO = FIO;
        }

        public void WriteToTextFile(StreamWriter file)
        {
            file.WriteLine(CarNumber);
            file.WriteLine(Brand);
            file.WriteLine(FIO);
        }

        public bool TryReadFromTextFile(StreamReader file)
        {
            CarNumber = defaultCarNumber;
            Brand = defaultBrand;
            FIO = defaultFIO;

            CarNumber = file.ReadLine();
            Brand = file.ReadLine();
            FIO = file.ReadLine();

            if (Brand == defaultBrand || FIO == defaultFIO)
                return false;

            return true;
        }
    }
}
