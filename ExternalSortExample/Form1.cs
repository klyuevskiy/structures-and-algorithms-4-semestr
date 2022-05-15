using ExternalSort;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();
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
            // генерируем задачи сортировок

            FillDataGridElementsNumbers();

            startCompressionToolStripMenuItem.Enabled = false;

            SortInformationPrinter sortInformationPrinter =
                new SortInformationPrinter(elapsedTimeDataGridView, passesNumberDataGridView, comparesNumberDataGridView);

            Task[] tasks = new Task[elementsNumbers.Length];

            for (int i = 0; i < elementsNumbers.Length; i++)
            {
                //new SortFiles(elementsNumbers[i], i, sortInformationPrinter).Start();
                tasks[i] = Task.Run(new SortFiles(elementsNumbers[i], i, sortInformationPrinter).Start);
            }

            Task.WaitAll(tasks);

            startCompressionToolStripMenuItem.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGridElementsNumbers();
        }
    }
}
