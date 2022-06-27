namespace ExternalSort
{
    class DoublyLinkedList
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

        public DoublyLinkedList()
        {
            ComparesNumber = 0;

            _head = null;
            _tail = null;
        }

        public bool IsEmpty() =>
            _head == null;

        // в списке будем поддерживать обратную отсортированность
        public void Add(int number, int fileIndex)
        {
            ListNode newNode = new ListNode(number, fileIndex);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
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
                //иначе ищем нужную позицию

                ListNode previous = _head, current = _head.Next;

                while (current != null && current.Number > number)
                {
                    ComparesNumber++;
                    previous = current;
                    current = current.Next;
                }

                newNode.Next = current;
                newNode.Prev = previous;

                if (current != null)
                    current.Prev = newNode;
                else
                    _tail = newNode;

                previous.Next = newNode;
            }
        }

        public (int, int) GetMin()
        {
            int number = _tail.Number,
                fileIndex = _tail.FileIndex;

            if (_tail.Prev != null)
                _tail.Prev.Next = null;

             _tail = _tail.Prev;

            if (_tail == null)
                _head = null;

            return (number, fileIndex);
        }
    }
}
