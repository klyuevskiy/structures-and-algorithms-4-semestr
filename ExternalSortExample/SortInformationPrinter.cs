using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        void PrintSortInformation(int rowIndex, int cellIndex, SortInformation sortInformation)
        {
            elapsedTimeDataGridView.Rows[rowIndex].Cells[cellIndex].Value =
                sortInformation.ElapsedTime.ElapsedMilliseconds;

            passesNumberDataGridView.Rows[rowIndex].Cells[cellIndex].Value =
                sortInformation.PassesNumber;

            comparesNumberDataGridView.Rows[rowIndex].Cells[cellIndex].Value =
                sortInformation.ComparesNumber;
        }

        public void PrintSortedFileSortInformation(int rowIndex, SortInformation sortInformation)
        {
            PrintSortInformation(rowIndex, 1, sortInformation);
        }

        public void PrintRandomFileSortInformation(int rowIndex, SortInformation sortInformation)
        {
            PrintSortInformation(rowIndex, 2, sortInformation);
        }

        public void PrintInverseFileSortInformation(int rowIndex, SortInformation sortInformation)
        {
            PrintSortInformation(rowIndex, 3, sortInformation);
        }
    }
}
