using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hash
{
    public partial class InputStringDialog : Form
    {
        public InputStringDialog()
        {
            InitializeComponent();
        }

        public InputStringDialog(string inputSuggestion, string stringName)
        {
            InitializeComponent();

            Text = inputSuggestion;
            this.stringName.Text = stringName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stringTextBox.Text == "")
                MessageBox.Show("Поле ввода пустое");
            else
            {
                DialogResult = DialogResult.OK;

                DataBank.InputString = stringTextBox.Text;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
