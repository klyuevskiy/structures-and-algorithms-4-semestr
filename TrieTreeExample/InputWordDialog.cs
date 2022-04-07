using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrieTreeExample
{
    public partial class InputWordDialog : Form
    {
        string inputWord = "";
        public string Value { get => inputWord; }

        public InputWordDialog()
        {
            InitializeComponent();
        }

        bool isCorrectWord(string word)
        {
            if (word == "")
                return false;

            foreach (char symbol in word)
                if (!TrieTree.IsValidChar(symbol))
                    return false;

            return true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!isCorrectWord(inputWordTextBox.Text))
                MessageBox.Show("Неправильно введено слово. Слово должно состоять только из русских букв");
            else
            {
                inputWord = inputWordTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
