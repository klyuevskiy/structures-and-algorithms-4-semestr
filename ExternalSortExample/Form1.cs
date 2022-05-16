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

            // запускаем потоки и запоминаем их, чтобы подождать их и сделать кнопку доступной
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < elementsNumbers.Length; i++)
            {
                tasks.AddRange(new SortFiles(elementsNumbers[i], i, sortInformationPrinter).Start());
            }

            Task.WaitAll(tasks.ToArray());

            startCompressionToolStripMenuItem.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGridElementsNumbers();
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
                SortFile sortedFile = new SortFile();

                sortedFile.OpenToWrite();

                foreach (var item in numbers)
                {
                    sortedFile.Write(item);
                }

                // сортируем
                IExternalSort sort = new NaturalMultipathMerging((int)Math.Log2(numbers.Length) + 1);

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
                    $"Затраченное время: {sortInformation.ElapsedTime.ElapsedMilliseconds}\n" +
                    $"Выполнено проходов: {sortInformation.PassesNumber}\n" +
                    $"Выполнено сравнений: {sortInformation.ComparesNumber}");
            }
        }
    }
}
