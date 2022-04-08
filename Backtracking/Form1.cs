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

namespace Backtracking
{
    public partial class Form1 : Form
    {
        string fileName = "";
        bool isSaveFile = true;

        public Form1()
        {
            InitializeComponent();
        }

        List<int> GetIntervals(string text, out bool isCorrectRead)
        {
            string[] stringIntervals = text.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            isCorrectRead = true;

            List<int> intervals = new List<int>();

            foreach (string interval in stringIntervals)
            {
                int number;
                bool result = Int32.TryParse(interval, out number);

                if (!result || number < 0)
                    isCorrectRead = false;
                else
                    intervals.Add(number);
            }

            return intervals;
        }

        void BusesToGridView(List<Bus> buses, DataGridView grid)
        {
            grid.Rows.Clear();

            grid.Rows.Add();

            grid.Rows[0].Cells[0].Value = "Количество автобусов:";
            grid.Rows[0].Cells[1].Value = buses.Count.ToString();

            foreach (Bus bus in buses)
            {
                int rowIndex = grid.Rows.Add();

                grid.Rows[rowIndex].Cells[0].Value = bus.FirstArrivalTime.ToString();

                if (bus.Interval != -1)
                {
                    grid.Rows[rowIndex].Cells[1].Value = bus.Interval.ToString();
                }
                else
                {
                    grid.Rows[rowIndex].Cells[1].Value = "Неизвестно";
                }
            }
        }

        void SolveTask()
        {
            bool isCorrectRead;
            List<int> intervals = GetIntervals(textBox1.Text, out isCorrectRead);

            if (!isCorrectRead)
                MessageBox.Show("Произошли ошибки при чтении данных.\n" +
                    "Должны быть записаны только числа, разделённые пробелами и знаками пропуска строки");


            if (intervals.Count == 0)
                MessageBox.Show("Интервалов движения автобусов нет");
            else
            {
                List<Bus> buses = Task.Solve(intervals);

                BusesToGridView(buses, dataGridView1);
            }
        }

        private void решитьЗаданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolveTask();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isSaveFile = false;
        }

        void Clear()
        {
            isSaveFile = false;
            textBox1.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        // имя файла обнуляется, всё отчищается
        void CreateFile()
        {
            // если прошлый файл не сохранён и отмена
            if (CheckFileIsNotSave() != DialogResult.Cancel)
            {
                Clear();
                fileName = "";
                isSaveFile = false;
            }
        }

        void ReadTextFile()
        {
            StreamReader file = new StreamReader(fileName);
            textBox1.Text = file.ReadToEnd();

            file.Close();
        }

        void OpenFile()
        {
            // если прошлый файл не отменёен и этот введён
            if (CheckFileIsNotSave() != DialogResult.Cancel && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;

                Clear();
                ReadTextFile();

                isSaveFile = true;
            }
        }

        void CloseFile()
        {
            if (CheckFileIsNotSave() != DialogResult.Cancel)
                Clear();
            isSaveFile = true;
        }

        DialogResult CheckFileIsNotSave()
        {
            if (isSaveFile)
                return DialogResult.Yes;

            DialogResult result = MessageBox.Show("Текущий файл не сохранён. Сохранить его?", "Файл не сохранён", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                SaveFile();
            }

            return result;
        }

        void WriteIntervalsToTextFile()
        {
            bool isCorrectRead;
            List<int> intervals = GetIntervals(textBox1.Text, out isCorrectRead);

            StreamWriter file = new StreamWriter(fileName);

            foreach (int interval in intervals)
                file.Write(interval.ToString() + ' ');

            file.Close();
        }

        void SaveFile()
        {
            // если файл не сохранён и нет имени файла, то сохранить как
            if (!isSaveFile && fileName == "")
                SaveAsFile();
            else if (!isSaveFile)
            {
                // есть имя, нр не сохранён сохраняем
                WriteIntervalsToTextFile();
                isSaveFile = true;
            }
        }

        void SaveAsFile()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                WriteIntervalsToTextFile();
                isSaveFile = true;
            }
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckFileIsNotSave() == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            CloseFile();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            SolveTask();
        }
    }
}
