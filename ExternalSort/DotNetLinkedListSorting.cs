using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSort
{
    class DotNetLinkedListSorting : ISortingStructure
    {
        public int ComparesNumber { get; private set; }

        LinkedList<(int, int)> list;

        public DotNetLinkedListSorting()
        {
            list = new LinkedList<(int, int)>();
        }

        public void Add(int number, int fileIndex)
        {
            if (list.Count == 0)
                list.AddFirst((number, fileIndex));
            else
            {
                LinkedListNode<(int, int)> node = new LinkedListNode<(int, int)>((number, fileIndex));

                ComparesNumber++;

                if (list.First.Value.Item1 <= number)
                    list.AddFirst(node);
                else
                {
                    var prev = list.First;
                    var cur = list.First.Next;

                    while (cur != null && cur.Value.Item1 > number)
                    {
                        ComparesNumber++;
                        prev = cur;
                        cur = cur.Next;
                    }

                    list.AddAfter(prev, node);
                }
            }
        }

        public (int, int) GetMin()
        {

            int number = list.Last.Value.Item1,
                fileIndex = list.Last.Value.Item2;

            list.RemoveLast();

            return (number, fileIndex);
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }
    }
}
