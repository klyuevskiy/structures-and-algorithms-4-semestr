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
        public Form1()
        {
            InitializeComponent();


            SortFile file = new SortFile("input.bin");

            int[] arr = new int[] { /*1, 2, 4, 1, 2, 1, 2, 1, 5, 6, 2, 3, 2, 7*/ 
            1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2};

            file.OpenToWrite();

            foreach (var item in arr)
            {
                file.Write(item);
            }

            NaturalMultipathMerging sort = new NaturalMultipathMerging(3);
            sort.Sort(file);

            file.OpenToRead();

            string s = "";
            while (!file.EndOfFile)
            {
                s += file.Read().ToString() + " ";
            }
            MessageBox.Show(s);
        }

    }
}
