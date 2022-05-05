using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace InternalSort
{
    class Visualization
    {
        private readonly RichTextBox _textBox;
        private readonly char[] _sortedArray;

        public class DrawingNode
        {
            public int Left { get; set; }
            public int Right { get; set; }
            public int BitNumber { get; set; }
            public int LeftIndex { get; set; }
            public int RightIndex { get; set; }
            public string Message { get; set; }
            public bool IsExchange { get; set; }

            public DrawingNode(int left, int right, int bitNumber, int leftIndex, int rightIndex, string message, bool isExchange)
            {
                Left = left;
                Right = right;
                BitNumber = bitNumber;
                LeftIndex = leftIndex;
                RightIndex = rightIndex;
                Message = message;
                IsExchange = isExchange;
            }
        }

        List<DrawingNode> _drawingNodes;

        public Visualization(RichTextBox textBox, char[] arr)
        {
            _textBox = textBox;
            _sortedArray = arr.Clone() as char[];
            _drawingNodes = new List<DrawingNode>();
        }

        public void AddNode(DrawingNode node)
        {
            _drawingNodes.Add(node);
        }

        private int GetMaxBit(char c)
        {
            int i = sizeof(char) * 8 - 1, bit = 1 << i;

            while (i >= 0)
            {
                if ((bit & c) != 0)
                    return i;
                i--;
                bit >>= 1;
            }

            return i;
        }

        public int GetMaxBit()
        {
            int max = 0;

            foreach (var item in _sortedArray)
            {
                max = Math.Max(max, GetMaxBit(item));
            }

            return max;
        }

        private string GetAllBitsChar(char c, int maxBit)
        {
            string result = "";
            int bit = 1 << maxBit;

            while (maxBit >= 0)
            {
                if ((bit & c) != 0)
                    result += "1";
                else
                    result += "0";

                maxBit--;
                bit >>= 1;
            }

            return result;
        }

        private int DrawNumber(char c, int position, int left, int right, int index, int maxBit, bool isHighlight, int bitNumber)
        {
            string bits = GetAllBitsChar(c, maxBit);
            _textBox.Text += bits + " ";

            // + 1 так как ещё пробел
            return position + bits.Length + 1;
        }

        private void HighligthGray(int left, int right, int maxBit, int textEnd)
        {
            // каждое число имеет длину maxBit + 1
            int itemLength = maxBit + 1;

            // выдлеим серым всё что за пределеми текущего
            _textBox.Select(0, itemLength * left + left);
            _textBox.SelectionColor = Color.Gray;

            int pos = (right + 1) * itemLength + right;
            _textBox.Select(pos, textEnd - pos);
            _textBox.SelectionColor = Color.Gray;
        }

        private void HighlightPointer(int index, int maxBit, int bitNumber)
        {
            int itemLength = maxBit + 1;
            _textBox.Select(index * itemLength + index + maxBit - bitNumber, 1);
            _textBox.SelectionColor = Color.Red;
        }

        private void Draw(DrawingNode node, int maxBit)
        {
            _textBox.Text = "";
            int position = 0;

            for (int i = 0; i < _sortedArray.Length; i++)
            {
                position = DrawNumber(_sortedArray[i], position, node.Left, node.Right,
                    i, maxBit, (i == node.LeftIndex || i == node.RightIndex), node.BitNumber);
            }

            _textBox.Text += $"\n\nРассматриваем подмассив [{node.Left + 1}; {node.Right + 1}]\n" +
                $"Сравниваем по {node.BitNumber + 1} разряду\n" +
                node.Message;

            HighligthGray(node.Left, node.Right, maxBit, position);
            HighlightPointer(node.LeftIndex, maxBit, node.BitNumber);
            HighlightPointer(node.RightIndex, maxBit, node.BitNumber);

            if (node.IsExchange)
            {
                char tmp = _sortedArray[node.LeftIndex];
                _sortedArray[node.LeftIndex] = _sortedArray[node.RightIndex];
                _sortedArray[node.RightIndex] = tmp;
            }
        }

        private string PrintArray()
        {
            string res = "",
                codes = "";
            foreach (var item in _sortedArray)
            {
                res += item + " ";
                codes += ((int)item).ToString() + " ";
            }
            return res + "\nКоды символов:\n" + codes;
        }

        public async Task Visualize()
        {
            _textBox.Text = "Введён массив:\n" + PrintArray();

            await Task.Delay(2000);

            int maxBit = GetMaxBit();

            foreach (var item in _drawingNodes)
            {
                Draw(item, maxBit);

                int delayTime = 2000;

                if (item.IsExchange)
                    delayTime += 2000;

                await Task.Delay(delayTime);
            }

            string message = "Массив отсортирован\n";
            string strArr = PrintArray();

            _textBox.Text = message + strArr;
        }
    }
}
