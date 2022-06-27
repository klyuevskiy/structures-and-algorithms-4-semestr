using System;
using System.Windows.Forms;

namespace ExternalSortExample
{
    public partial class TestForm : Form
    {
        // количество элемнентов по которым будет проводиться сравнение
        int[] elementsNumbers = new int[]
        {
            1000,
            5000,
            10000,
            50000,
        };

        SortInformationPrinter sortInformationPrinter;

        public TestForm()
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

        void FillDataGridsElementsNumbers()
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

        void startCompressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startCompressionToolStripMenuItem.Enabled = false;

            // чистим и заполняем grid
            FillDataGridsElementsNumbers();

            int filesNumber = Int32.Parse(filesNumberTextBox.Text);

            for (int i = 0; i < elementsNumbers.Length; i++)
            {
                new SortFiles(elementsNumbers[i], i, sortInformationPrinter, filesNumber).Start();
            }

            startCompressionToolStripMenuItem.Enabled = true;
        }
    }
}
