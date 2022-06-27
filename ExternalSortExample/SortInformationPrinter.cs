using System.Windows.Forms;
using ExternalSort;

namespace ExternalSortExample
{
    class SortInformationPrinter
    {
        private readonly DataGridView elapsedTimeDataGridView;
        private readonly DataGridView passesNumberDataGridView;
        private readonly DataGridView comparesNumberDataGridView;

        public SortInformationPrinter(DataGridView elapsedTimeDataGridView,
            DataGridView passesNumberDataGridView,
            DataGridView comparesNumberDataGridView)
        {
            this.elapsedTimeDataGridView = elapsedTimeDataGridView;
            this.passesNumberDataGridView = passesNumberDataGridView;
            this.comparesNumberDataGridView = comparesNumberDataGridView;
        }

        void PrintSortInformation(int rowIndex, int columnIndex, SortInformation sortInformation)
        {
            elapsedTimeDataGridView.Rows[rowIndex].Cells[columnIndex].Value =
                sortInformation.ElapsedTime.ElapsedMilliseconds;

            passesNumberDataGridView.Rows[rowIndex].Cells[columnIndex].Value =
                sortInformation.PassesNumber;

            comparesNumberDataGridView.Rows[rowIndex].Cells[columnIndex].Value =
                sortInformation.ComparesNumber;
        }

        public void PrintSortedFileInformation(int rowIndex, SortInformation sortInformation) =>
            PrintSortInformation(rowIndex, 1, sortInformation);

        public void PrintRandomFileInformation(int rowIndex, SortInformation sortInformation) =>
            PrintSortInformation(rowIndex, 2, sortInformation);

        public void PrintInverseFileInformation(int rowIndex, SortInformation sortInformation) =>
            PrintSortInformation(rowIndex, 3, sortInformation);
    }
}
