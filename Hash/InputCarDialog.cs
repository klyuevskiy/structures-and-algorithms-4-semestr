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
    public partial class InputCarDialog : Form
    {
        public InputCarDialog()
        {
            InitializeComponent();
        }

        // конструктор для отображения информации о передаваемой машине
        public InputCarDialog(Car car)
        {
            InitializeComponent();

            carNumberTextBox.Text = car.CarNumber;
            brandTextBox.Text = car.Brand;
            FIOTextBox.Text = car.FIO;

            // вместо названия формы сделаем номер машины
            Text = car.CarNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (carNumberTextBox.Text == "" || brandTextBox.Text == "" || FIOTextBox.Text == "")
                MessageBox.Show("Вы заполнили не все поля");
            else
            {
                try
                {
                    DataBank.InputCar = new Car(carNumberTextBox.Text, brandTextBox.Text, FIOTextBox.Text);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch(Exception except)
                {
                    MessageBox.Show(except.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
