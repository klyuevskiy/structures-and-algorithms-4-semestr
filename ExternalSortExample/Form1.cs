using ExternalSort;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ExternalSortExample
{
    public partial class Form1 : Form
    {
        // количество элемнентов по которым будет проводиться сравнение
        int[] elementsNumbers = new int[]
        {
            1000,
            5000,
            10000,
            50000
        };

        IEnumerable<Type> sortingStructureTypes;
        Type sortingStructureType;

        SortInformationPrinter sortInformationPrinter;

        public Form1()
        {
            InitializeComponent();

            sortInformationPrinter =
                new SortInformationPrinter(elapsedTimeDataGridView, passesNumberDataGridView, comparesNumberDataGridView);
        }

        void AddElementsNumberToDataGrid(DataGridView dataGrid, int elementsNumber)
        {
            dataGrid.Rows[dataGrid.Rows.Add()]
                .Cells[0].Value = elementsNumber;
        }

        void FillDataGridElementsNumbers()
        {
            elapsedTimeDataGridView.Rows.Clear();
            passesNumberDataGridView.Rows.Clear();
            comparesNumberDataGridView.Rows.Clear();

            foreach (var item in elementsNumbers)
            {
                AddElementsNumberToDataGrid(elapsedTimeDataGridView, item);
                AddElementsNumberToDataGrid(passesNumberDataGridView, item);
                AddElementsNumberToDataGrid(comparesNumberDataGridView, item);
            }
        }

        private void startCompressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startCompressionToolStripMenuItem.Enabled = false;

            // чистим и заполняем grid
            FillDataGridElementsNumbers();

            for (int i = 0; i < elementsNumbers.Length; i++)
            {
                new SortFiles(sortingStructureType, elementsNumbers[i], i, sortInformationPrinter).Start();
            }

            startCompressionToolStripMenuItem.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGridElementsNumbers();

            // fill combobox

            sortingStructureTypes = Assembly.Load("ExternalSort").GetTypes()
                .Where(type => type.GetInterface("ISortingStructure") != null);

            selectSortingStructure.Items.AddRange(
                sortingStructureTypes.Select(type => type.Name).ToArray());
        }

        private void sortUserFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // запросим ввести файл
            if (openUserFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openUserFileDialog.FileName;
                // если ввели то сортируем
                // читаем значения и доавляем в бинарный файл

                StreamReader readFile = new StreamReader(fileName);

                // считываем файл
                int[] numbers = readFile.ReadToEnd()
                    .Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(s =>
                    {
                        int res;
                        return Int32.TryParse(s, out res);
                    })
                    .Select(s => Int32.Parse(s))
                    .ToArray();

                readFile.Close();

                // записываем в бинарный
                BinaryFile sortedFile = new BinaryFile();

                sortedFile.OpenToWrite();

                foreach (var item in numbers)
                {
                    sortedFile.Write(item);
                }

                // сортируем
                IExternalSort sort = new NaturalMultipathMerging(sortingStructureType, (int)Math.Log2(numbers.Length) + 1);

                SortInformation sortInformation = sort.Sort(sortedFile);

                // перезаписываем информацию обратно
                StreamWriter writeFile = new StreamWriter(fileName);

                sortedFile.OpenToRead();

                int i = 0;
                while (!sortedFile.EndOfFile)
                {
                    writeFile.Write(sortedFile.Read().ToString() + " ");

                    i++;

                    if (i % 10 == 0)
                        writeFile.Write("\n");
                }

                sortedFile.Delete();
                writeFile.Close();

                MessageBox.Show($"Файл отсортирован\n" +
                    $"Затраченное время: {sortInformation.ElapsedTime.ElapsedMilliseconds} мс\n" +
                    $"Выполнено проходов: {sortInformation.PassesNumber}\n" +
                    $"Выполнено сравнений: {sortInformation.ComparesNumber}");
            }
        }

        private void selectSortingStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            startCompressionToolStripMenuItem.Enabled = true;
            sortUserFileToolStripMenuItem.Enabled = true;

            sortingStructureType = sortingStructureTypes.First(type => type.Name == selectSortingStructure.SelectedItem.ToString());
        }
    }
}
