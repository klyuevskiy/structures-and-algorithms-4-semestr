using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternalSort
{
    public partial class Form1 : Form
    {
        Visualization visualization;

        public Form1()
        {
            InitializeComponent();
        }

        char[] GetCharArray()
        {
            // достать все символы кроме пробельных
            return string.Concat(textBox1.Text
                .Where(c => !char.IsWhiteSpace(c)))
                .ToCharArray();
        }

        private void отсортироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] arr = GetCharArray();

            // создать объекты визуализации и сортировки
            visualization = new Visualization(richTextBox1, arr);
            Sort sort = new Sort(visualization);

            // пока сортируется нельзя больше запросить отсортировать
            отсортироватьToolStripMenuItem.Enabled = false;
            следующаяПерестановкаToolStripMenuItem.Enabled = true;

            // сортировка + визуализация
            sort.RadixSort(arr);
            visualization.StartVisualize();
            //await visualization.Visualize();

            // можно сортировать
            //отсортироватьToolStripMenuItem.Enabled = true;
        }

        private void следующаяПерестановкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!visualization.VisualiseNextExchange())
            {
                отсортироватьToolStripMenuItem.Enabled = true;
                следующаяПерестановкаToolStripMenuItem.Enabled = false;
            }
        }
    }
}
