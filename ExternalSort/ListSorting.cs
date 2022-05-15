using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSort
{
    class ListSorting : ISortingStructure
    {
        class ListNode
        {
            public int Number { get; set; }
            public int FileIndex { get; set; }
            public ListNode Next { get; set; }

            public ListNode(int data, int fileIndex)
            {
                Number = data;
                FileIndex = fileIndex;
                Next = null;
            }
        }

        public int ComparesNumber { get; private set; }

        private ListNode _head;

        public ListSorting()
        {
            ComparesNumber = 0;
            _head = null;
        }

        public void Add(int number, int fileIndex)
        {
            ListNode newNode = new ListNode(number, fileIndex);

            // голова пустая, сатвим на её место
            if (_head == null)
            {
                _head = newNode;
            }
            // меньше головы, ставим на её место
            else if (number < _head.Number)
            {
                ComparesNumber++;
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {
                ComparesNumber++;
                // иначе ищем нужную позицию
                ListNode previous = _head, current = _head.Next;

                while (current != null && current.Number < number)
                {
                    ComparesNumber++;
                    previous = current;
                    current = current.Next;
                }

                newNode.Next = current;
                previous.Next = newNode;
            }
        }

        public (int, int) GetMin()
        {
            // нет проверки на пустоту ради производительности

            int number = _head.Number,
                fileIndex = _head.FileIndex;
            
            _head = _head.Next;

            return (number, fileIndex);
        }

        public bool IsEmpty()
        {
            return _head == null;
        }
    }
}
