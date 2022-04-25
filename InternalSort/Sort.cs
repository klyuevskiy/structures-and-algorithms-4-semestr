using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalSort
{
    class Sort
    {
        private readonly Visualization visualization;

        public Sort(Visualization visualization)
        {
            this.visualization = visualization;
        }

        public void RadixSort(char[] arr)
        {
            // задаём левую и правую границу и номер страшего бита(начиная с 0, поэтому -1)
            RadixSort(arr, 0, arr.Length - 1, sizeof(char) * 8 - 1);
        }

        void RadixSort(char[] arr, int left, int right, int bitNumber)
        {
            // если дошли до отрицательного разряда, значит всё прошли => выход
            // левая граница > правой - не сортируем выход
            // левая = правой - сортируем 1 значение выход
            if (left >= right || bitNumber < 0)
                return;

            // получаем инлексы для итерирования и бит, с которым будем сравнивать
            int i = left, j = right, bit = 1 << bitNumber;

            // сортируем так, что слева будут 0, справа 1

            // пока инлексы не дошли друг до друга
            while (i < j)
            {
                // ищем слева 1 в разряде
                while ((arr[i] & bit) == 0 && i < j)
                    i++;
                // ищем справа 0 в разряде
                while ((arr[j] & bit) != 0 && i < j)
                    j--;

                // нашли пару значений 1 и 0, меняем
                if (i < j)
                {
                    // добавим обмен для визуализации
                    visualization.AddExchange(i, j, bitNumber);

                    // обмен
                    char tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;

                    // сразу сдвинем индесы, чтобы снова не проверять их
                    i++;
                    j--;
                }
            }

            // этот разряд прошли, идём дальше
            bitNumber--;

            // сортируем справа и слева

            // i = j - разделитель между 0 и 1
            // в зависимости от бита который там стоит определим границы

            if ((arr[i] & bit) == 0)
            {
                RadixSort(arr, i + 1, right, bitNumber);
                RadixSort(arr, left, i, bitNumber);
            }
            else
            {
                RadixSort(arr, i, right, bitNumber);
                RadixSort(arr, left, i - 1, bitNumber);
            }
        }
    }
}
