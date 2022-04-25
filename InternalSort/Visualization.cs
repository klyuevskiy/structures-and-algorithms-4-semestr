using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace InternalSort
{
    // класс визуализации
    class Visualization
    {
        private readonly RichTextBox textBox;
        private readonly char[] sortArray;
        int exchangeIndex;

        // содержит список обменов
        // один обмен = индексы элементов + разряд сравенения

        // узел, который будет хранится в списке
        class Exchange
        {
            public int FirstIndex { get; set; }
            public int SecondIndex { get; set; }
            public int BitNumber { get; set; }
            
            public Exchange(int firstIndex, int secondIndex, int bitNumber)
            {
                FirstIndex = firstIndex;
                SecondIndex = secondIndex;
                BitNumber = bitNumber;
            }
        }

        public Visualization(RichTextBox textBox, char[] sortArray)
        {
            this.textBox = textBox;

            // клонирование а не ссылка, чтобы после сортировки начальный массив высвечивать
            this.sortArray = sortArray.Clone() as char[];
            exchanges = new List<Exchange>();
        }

        List<Exchange> exchanges;

        public void AddExchange(int firstIndex, int secondIndex, int bitNumber)
        {
            exchanges.Add(new Exchange(firstIndex, secondIndex, bitNumber));
        }

        // печать массива
        string PrintArray()
        {
            // печать массива и кодов символов(чтобы понимать что правильно отсортировано)

            string chars = "",
                charCodes = "";
            foreach (var item in sortArray)
            {
                chars += item.ToString() + " ";
                charCodes += ((int)item).ToString() + " ";
            }

            return chars + "\nКоды символов: " + charCodes;
        }

        // выделить цветом букву
        void HighlightItem(int index)
        {
            textBox.Select(2 * index, 1);
            textBox.SelectionColor = Color.Brown;
        }

        public void StartVisualize()
        {
            // сортируем так обмены, чтобы были изначально обмены страших битов
            // так как реализация сортировки через рекурсию, то там другой порядок
            // на результат не влияет, но нагляднее
            exchanges.Sort((a, b) => b.BitNumber - a.BitNumber);
            exchangeIndex = 0;
            textBox.Text = "Исходный массив: " + PrintArray();
        }

        // отобразить следующий обмен true - если дальше есть обмены
        public bool VisualiseNextExchange()
        {
            if (exchangeIndex >= exchanges.Count)
            {
                textBox.Text = "Отсортированный массив: " + PrintArray();
                return false;
            }

            textBox.Text = PrintArray();

            int firstIndex = exchanges[exchangeIndex].FirstIndex,
                secondIndex = exchanges[exchangeIndex].SecondIndex,
                bitNumber = exchanges[exchangeIndex].BitNumber;

            exchangeIndex++;

            // печать сообщения = разряд бита + номера элементов + элементы + их двоичное представление
            textBox.Text += $"\nСравниваем по разряду {bitNumber + 1}\n" +
                $"Меняем элементы с номерами {firstIndex + 1}, {secondIndex + 1}\n" +
                $"Меняемые значения {sortArray[firstIndex]}({Convert.ToString(sortArray[firstIndex], 2)}), " +
                $"{sortArray[secondIndex]}({Convert.ToString(sortArray[secondIndex], 2)})";

            HighlightItem(firstIndex);
            HighlightItem(secondIndex);

            char tmp = sortArray[firstIndex];
            sortArray[firstIndex] = sortArray[secondIndex];
            sortArray[secondIndex] = tmp;

            return true;
        }

        // функция полность сама выводит обмены
        // написал вначале её, но потом решил сделать кнопку следующего обмена
        public async Task Visualize()
        {
            exchanges.Sort((a, b) => b.BitNumber - a.BitNumber);

            foreach (var item in exchanges)
            {
                textBox.Text = PrintArray();

                await Task.Delay(1500);

                textBox.Text += $"\nСравниваем по разряду {item.BitNumber + 1}\n" +
                    $"Меняем элементы с номерами {item.FirstIndex + 1}, {item.SecondIndex + 1}\n" +
                    $"Меняемые значения {sortArray[item.FirstIndex]}({Convert.ToString(sortArray[item.FirstIndex], 2)}), " +
                    $"{sortArray[item.SecondIndex]}({Convert.ToString(sortArray[item.SecondIndex], 2)})";

                await Task.Delay(1500);

                HighlightItem(item.FirstIndex);
                HighlightItem(item.SecondIndex);

                char tmp = sortArray[item.FirstIndex];
                sortArray[item.FirstIndex] = sortArray[item.SecondIndex];
                sortArray[item.SecondIndex] = tmp;

                await Task.Delay(1500);
            }

            // конечная печать
            textBox.Text = "Отсортированный массив\n" + PrintArray();
        }
    }
}
