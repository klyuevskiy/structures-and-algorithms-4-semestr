using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSort
{
    class AVLTreeSorting : ISortingStructure
    {
        public int ComparesNumber { get; private set; }

        class Node
        {
            public int Key { get; set; }
            public int FileIndex { get; set; }
            
            public Node Left { get; set; }
            public Node Right { get; set; }

            public sbyte Height { get; set; }

            public Node(int key, int fileIndex)
            {
                Key = key;
                FileIndex = fileIndex;

                Left = null;
                Right = null;

                Height = 1;
            }
        }

        Node _head;

        public AVLTreeSorting()
        {
            _head = null;
        }

        int Height(Node node)
        {
            return node == null ? 0 : (sbyte)node.Height;

        }

        int BalanceFactor(Node node)
        {
            return Height(node.Right) - Height(node.Left);
        }

        void UpdateHeight(Node node)
        {
            int hl = Height(node.Left),
                hr = Height(node.Right);

            node.Height = (sbyte)((hl > hr ? hl : hr) + 1);
        }

        Node RotateRight(Node node)
        {
            Node q = node.Left;
            node.Left = q.Right;
            q.Right = node;

            UpdateHeight(node);
            UpdateHeight(q);

            return q;
        }

        Node RotateLeft(Node node)
        {
            Node q = node.Right;
            node.Right = q.Left;
            q.Left = node;

            UpdateHeight(node);
            UpdateHeight(q);

            return q;
        }

        Node Balance(Node node)
        {
            UpdateHeight(node);

            if (BalanceFactor(node) == 2)
            {
                if (BalanceFactor(node.Right) < 0)
                    node.Right = RotateRight(node.Right);

                return RotateLeft(node);
            }

            if (BalanceFactor(node) == -2)
            {
                if (BalanceFactor(node.Left) > 0)
                    node.Left = RotateLeft(node.Left);

                return RotateRight(node);
            }

            return node;
        }

        Node AddRecursive(Node node, int key, int fileIndex)
        {
            if (node == null)
                return new Node(key, fileIndex);

            ComparesNumber++;

            if (key < node.Key)
                node.Left = AddRecursive(node.Left, key, fileIndex);
            else
                node.Right = AddRecursive(node.Right, key, fileIndex);

            return Balance(node);
        }

        public void Add(int number, int fileIndex)
        {
            _head = AddRecursive(_head, number, fileIndex);
        }

        (int, int) FindMin(Node node)
        {
            return node.Left != null ? FindMin(node.Left) : (node.Key, node.FileIndex);
        }

        Node RemoveMin(Node node)
        {
            if (node.Left == null)
                return node.Right;

            node.Left = RemoveMin(node.Left);

            return Balance(node);
        }

        public (int, int) GetMin()
        {
            (int, int) res = FindMin(_head);
            _head = RemoveMin(_head);

            return res;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }
    }
}
