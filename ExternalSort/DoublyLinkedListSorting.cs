using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSort
{
    class DoublyLinkedListSorting : ISortingStructure
    {
        public int ComparesNumber { get; private set; }

        class ListNode
        {
            public int Number { get; set; }
            public int FileIndex { get; set; }
            public ListNode Next { get; set; }
            public ListNode Prev { get; set; }

            public ListNode(int data, int fileIndex)
            {
                Number = data;
                FileIndex = fileIndex;

                Next = null;
                Prev = null;
            }
        }

        private ListNode _head, _tail;

        public DoublyLinkedListSorting()
        {
            ComparesNumber = 0;

            _head = null;
            _tail = null;
        }

        // в списке будем поддерживать обратную отсортированность
        public void Add(int number, int fileIndex)
        {
            ListNode newNode = new ListNode(number, fileIndex);

            // голова пустая, сатвим на её место
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            // меньше головы, ставим на её место
            else if (number >= _head.Number)
            {
                ComparesNumber++;

                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
            else
            {
                ComparesNumber++;
                // иначе ищем нужную позицию

                ListNode previous = _head, current = _head.Next;

                while (current != null && current.Number > number)
                {
                    ComparesNumber++;
                    previous = current;
                    current = current.Next;
                }

                newNode.Next = current;
                newNode.Prev = previous;

                // current can be null
                if (current != null)
                    current.Prev = newNode;
                else
                    _tail = newNode;

                previous.Next = newNode;
            }
        }

        public (int, int) GetMin()
        {
            // нет проверки на пустоту ради производительности

            int number = _tail.Number,
                fileIndex = _tail.FileIndex;

            _tail = _tail.Prev;

            if (_tail == null)
                _head = null;

            return (number, fileIndex);
        }

        public bool IsEmpty()
        {
            return _head == null;
        }
    }
}
