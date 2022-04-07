using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hash
{
    public partial class Form1 : Form
    {
        HashTable carsTable = new HashTable();

        // имя текущего файла, пустое имя, если файл не открыт
        string fileName = "";

        public Form1()
        {
            InitializeComponent();
        }

        void WriteHashTableToXmlFile(string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(HashTable));
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(stream, carsTable);
            stream.Close();
        }

        void ReadHashTableFromXmlFile(string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(HashTable));
            FileStream stream = new FileStream(fileName, FileMode.Open);
            carsTable = formatter.Deserialize(stream) as HashTable;
            stream.Close();
        }

        void WriteHashTableToBinaryFile(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(stream, carsTable);
            stream.Close();
        }

        void ReadHashTableFromBinaryFile(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(fileName, FileMode.Open);
            carsTable = formatter.Deserialize(stream) as HashTable;
            stream.Close();
        }

        void WriteHashTableToFile(string fileName)
        {
            try
            {
                switch (Path.GetExtension(fileName))
                {
                    case ".txt":
                        carsTable.WriteToTextFile(fileName);
                        break;
                    case ".bin":
                        WriteHashTableToBinaryFile(fileName);
                        break;
                    case ".xml":
                        WriteHashTableToXmlFile(fileName);
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        void ReadHashTableFromFile(string fileName)
        {
            try
            {
                switch (Path.GetExtension(fileName))
                {
                    case ".txt":
                        carsTable.TryReadFromTextFile(fileName);
                        break;
                    case ".bin":
                        ReadHashTableFromBinaryFile(fileName);
                        break;
                    case ".xml":
                        ReadHashTableFromXmlFile(fileName);
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        void ShowCarsNumbers()
        {
            listBox1.Items.Clear();
            List<string> carsNumbers = carsTable.ToStringList();

            foreach (var i in carsNumbers)
                listBox1.Items.Add(i);
        }

        private void AddCar()
        {
            InputCarDialog inputCarDialog = new InputCarDialog();
            DialogResult result = inputCarDialog.ShowDialog();


            if (result == DialogResult.OK)
            {
                Car newCar = DataBank.InputCar;

                try
                {
                    carsTable.Add(newCar.CarNumber, newCar);
                    listBox1.Items.Add(newCar.ToString());
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void FindCar()
        {
            InputStringDialog inputCarNumberDialog = new InputStringDialog();
            DialogResult result = inputCarNumberDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Car car = carsTable.Find(DataBank.InputString);

                if (car == null)
                    MessageBox.Show("Машина не найдена");
                else
                {
                    InputCarDialog showCar = new InputCarDialog(car);
                    result = showCar.ShowDialog();

                    // изменили данные, обновим их
                    if (result == DialogResult.OK)
                    {
                        // если номер поменялся, то меняем номер в listBox
                        if (car.ToString() != DataBank.InputCar.ToString())
                        {
                            listBox1.Items.Remove(car.ToString());
                            listBox1.Items.Add(DataBank.InputCar.ToString());
                        }

                        // меняем информацию в хеш таблице
                        carsTable.Remove(car.CarNumber);
                        carsTable.Add(DataBank.InputCar.CarNumber, DataBank.InputCar);
                    }
                }
            }
        }

        private void RemoveCar()
        {
            InputStringDialog inputCarNumberDialog = new InputStringDialog();
            DialogResult result = inputCarNumberDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Car car = carsTable.Find(DataBank.InputString);

                if (car != null)
                {
                    carsTable.Remove(DataBank.InputString);
                    listBox1.Items.Remove(car.ToString());
                }
                else
                    MessageBox.Show("Машина не найдена");
            }
        }

        private void Clear()
        {
            carsTable = new HashTable();
            listBox1.Items.Clear();
        }

        private void CreateFile()
        {
            InputStringDialog inputFileNameDialog = new InputStringDialog("Введите имя файла", "Имя файла:");
            DialogResult result = inputFileNameDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    string extension = Path.GetExtension(DataBank.InputString);

                    if (extension != ".txt" && extension != ".bin" && extension != ".xml")
                        MessageBox.Show("Можно создать только файлы с расширением .txt .bin .xml");
                    else
                    {
                        fileName = DataBank.InputString;
                        File.Create(DataBank.InputString);
                    }
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка.\n" +
                        "Проверьте корректность имени файла");
                }
            }
        }

        private void OpenFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;

                ReadHashTableFromFile(fileName);
                ShowCarsNumbers();
            }
        }

        private void SaveFile()
        {
            if (fileName != "")
            {
                WriteHashTableToFile(fileName);
            }
        }

        private void SaveAsFile()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                WriteHashTableToFile(fileName);
            }
        }

        private void CloseFile()
        {
            fileName = "";
            listBox1.Items.Clear();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCar();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindCar();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCar();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseFile();
        }

        private void createFileButton_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            CloseFile();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddCar();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            RemoveCar();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            FindCar();
        }
    }
}
