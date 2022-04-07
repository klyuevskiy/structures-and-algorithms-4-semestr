using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TrieTreeExample
{

    [Serializable]
    public class TrieTree
    {
        public static bool IsValidChar(char c)
        {
            c = Char.ToLower(c);
            return c == 'ё' || (c >= 'а' && c <= 'я') || (c >= 'a' && c <= 'z');
        }

        int GetCharIndex(char c)
        {
            if (c >= 'a' && c <= 'z')
                return c - 'a';

            if (c >= 'а' && c <= 'е')
                return c - 'а' + 26;

            if (c == 'ё')
                return 32; // 6 - позиция ё в алфавите и 26 - анг алфавит 6 + 26 = 32

            return c - 'а' + 27; // смещение - англ + ё
        }

        const int alphabetSize = 59;

        // ключ - слово, значение - кол-во слов
        [Serializable]
        public class Node
        {
            // из-за того, что значение = кол-ву слов не нужен флаг конца слова
            // если значение = 0 - это промежуточный узел, != 0 - слово
            char key;
            
            public char Key
            {
                get => key;
                set
                {
                    if (value != ' ' && !IsValidChar(value))
                        throw new ArgumentException("Недопустимая буква");

                    key = value;
                }
            }

            public int WordsCount { get; set; }

            public Node[] Childs { get; set; } = new Node[alphabetSize];

            public Node()
            {
                Key = ' ';
                WordsCount = 0;
            }

            public Node(char key, int value)
            {
                Key = key;
                WordsCount = value;
            }
        }

        Node root;
        public Node Root
        {
            get => root;
            set => root = value;
        }

        public TrieTree()
        {
            Root = new Node();
        }

        public void Clear()
        {
            Root = new Node();
        }

        void Add(Node node, string key, int pos)
        {
            if (pos == key.Length)
                node.WordsCount++;
            else
            {
                int index = GetCharIndex(key[pos]);

                if (node.Childs[index] == null)
                    node.Childs[index] = new Node(key[pos], 0);

                Add(node.Childs[index], key, pos + 1);
            }
        }

        public void Add(string key)
        {
            Add(Root, key.ToLower(), 0);
        }

        int Find(Node node, string key, int pos)
        {
            if (node != null)
            {
                if (pos < key.Length)
                    return Find(node.Childs[GetCharIndex(key[pos])], key, pos + 1);

                return node.WordsCount;
            }

            return 0;
        }

        public int Find(string key)
        {
            return Find(Root, key.ToLower(), 0);
        }

        bool AllEmpty(Node node)
        {
            bool allEmpty = true;
            int i = 0;

            while (i < node.Childs.Length && allEmpty)
            {
                allEmpty = node.Childs[i] == null;
                i++;
            }

            return allEmpty;
        }

        // Ррекурсиыное удалени, true - если значение удалено
        bool Remove(ref Node node, string key, int pos)
        {
            if (node != null)
            {
                bool isRemoved = true;

                if (pos < key.Length)
                    isRemoved = Remove(ref node.Childs[GetCharIndex(key[pos])], key, pos + 1);
                else
                {
                    // если это не слово, то оставить ноль, если слово, то уменьшить счётчик
                    if (node.WordsCount != 0)
                        node.WordsCount--;
                }

                // если все потомки пустые и это промежуточный узел, то удалим его
                if (isRemoved && AllEmpty(node) && node.WordsCount == 0 && node != root)
                    node = null;

                return isRemoved;
            }

            return false;
        }

        // удалени, true - если значение удалено
        public bool Remove(string key)
        {
            return Remove(ref root, key.ToLower(), 0);
        }

        void ToTreeView(TreeNode treeViewNode, Node trieTreeNode)
        {
            foreach (Node trieTreeChild in trieTreeNode.Childs)
            {
                if (trieTreeChild != null)
                {
                    TreeNode treeViewChild = new TreeNode(trieTreeChild.Key.ToString());
                    treeViewNode.Nodes.Add(treeViewChild);

                    ToTreeView(treeViewChild, trieTreeChild);
                }
            }
        }

        public void ToTreeView(TreeView tree)
        {
            tree.Nodes.Clear();

            TreeNode treeViewNode = new TreeNode(Root.Key.ToString());

            tree.Nodes.Add(treeViewNode);

            ToTreeView(treeViewNode, Root);
        }

        void SolveTask(Node node, string word, DataGridView answer)
        {
            // восстанавливам слово
            if (node != root)
                word += node.Key.ToString();

            if (node.WordsCount > 0)
            {
                int index = answer.Rows.Add();
                answer.Rows[index].Cells[0].Value = word;
                answer.Rows[index].Cells[1].Value = node.WordsCount;
            }

            foreach (Node child in node.Childs)
                if (child != null)
                    SolveTask(child, word, answer);
        }

        public void SolveTask(DataGridView answer)
        {
            answer.Rows.Clear();
            SolveTask(Root, "", answer);
        }

        void ToTextFile(Node node, string word, StreamWriter file)
        {
            // восстанавливам слово
            if (node != root)
                word += node.Key.ToString();

            // есть слова, все их запишем в файл через пробел
            if (node.WordsCount > 0)
                for (int i = 0; i < node.WordsCount; i++)
                    file.Write(word + " ");

            // проверим потомков и добавим их
            foreach (Node child in node.Childs)
                if (child != null)
                    ToTextFile(child, word, file);
        }

        public void ToTextFile(string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
            ToTextFile(Root, "", file);

            file.Close();
        }
    }
}
