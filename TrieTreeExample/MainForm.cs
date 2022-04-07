using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace TrieTreeExample
{
    public partial class MainForm : Form
    {
        TrieTree tree = new TrieTree();

        string fileName = "";
        bool isSaveFile = true;

        public MainForm()
        {
            InitializeComponent();
        }

        void AddWord()
        {
            InputWordDialog inputWord = new InputWordDialog();

            if (inputWord.ShowDialog() == DialogResult.OK)
            {
                tree.Add(inputWord.Value);
                tree.ToTreeView(treeView1);
                isSaveFile = false;
            }
        }

        void RemoveWord()
        {
            InputWordDialog inputWord = new InputWordDialog();

            if (inputWord.ShowDialog() == DialogResult.OK)
            {
                isSaveFile = !tree.Remove(inputWord.Value) && isSaveFile;
                tree.ToTreeView(treeView1);
            }

        }

        void SolveTask()
        {
            tree.SolveTask(dataGridView1);
        }

        void FindWord()
        {
            InputWordDialog inputWord = new InputWordDialog();

            if (inputWord.ShowDialog() == DialogResult.OK)
            {
                int wordsCount = tree.Find(inputWord.Value);

                if (wordsCount == 0)
                    MessageBox.Show("Такое слово не найдено");
                else
                    MessageBox.Show("Слово " + inputWord.Value + " найдено.\n" +
                        "Количество таких слов: " + wordsCount.ToString());
            }
        }

        void Clear()
        {
            tree.Clear();
            treeView1.Nodes.Clear();
            dataGridView1.Rows.Clear();
            isSaveFile = false;

            tree.ToTreeView(treeView1);
        }

        // имя файла обнуляется, всё отчищается
        void CreateFile()
        {
            // если прошлый файл не сохранён и отмена
            if (CheckFileIsNotSave() != DialogResult.Cancel)
            {
                Clear();
                fileName = "";
                isSaveFile = false;
            }

        }

        void OpenFile()
        {
            // если прошлый файл не отменёен и этот введён
            if (CheckFileIsNotSave() != DialogResult.Cancel && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;

                ReadTrieTreeFromFile(fileName);
                tree.ToTreeView(treeView1);

                isSaveFile = true;
            }
        }

        void SaveAsFile()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                WriteTrieTreeToFile(fileName);
                isSaveFile = true;
            }
        }

        void SaveFile()
        {
            // если файл не сохранён и нет имени файла, то сохранить как
            if (!isSaveFile && fileName == "")
                SaveAsFile();
            else if (!isSaveFile)
            {
                // есть имя, нр не сохранён сохраняем
                WriteTrieTreeToFile(fileName);
                isSaveFile = true;
            }
        }

        void CloseFile()
        {
            if (CheckFileIsNotSave() != DialogResult.Cancel)
                Clear();
            isSaveFile = true;
        }

        DialogResult CheckFileIsNotSave()
        {
            if (isSaveFile)
                return DialogResult.Yes;

            DialogResult result = MessageBox.Show("Текущий файл не сохранён. Сохранить его?", "Файл не сохранён", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                SaveFile();
            }

            return result;
        }

        void ReadTrieTreeFromXmlFile(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TrieTree));
            StreamReader file = new StreamReader(fileName);

            tree = serializer.Deserialize(file) as TrieTree;
            file.Close();
        }

        void WriteTrieTreeToXmlFile(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TrieTree));
            StreamWriter file = new StreamWriter(fileName);

            serializer.Serialize(file, tree);
            file.Close();
        }

        // достать все русские слова из текста, всё остальное игнорируется
        List<string> GetWords(string text)
        {
            int wordStart = -1, wordEnd = 0, wordLength;

            List<string> words = new List<string>();

            while(wordEnd < text.Length)
            {
                // слово закончилось
                if (!TrieTree.IsValidChar(text[wordEnd]))
                {
                    wordLength = wordEnd - 1 - wordStart;
                    
                    if (wordLength > 0)
                        words.Add(text.Substring(wordStart + 1, wordLength));

                    wordStart = wordEnd;
                }

                wordEnd++;
            }

            // проверим, что получилось в конце
            wordLength = wordEnd - 1 - wordStart;
            if (wordLength > 0)
                words.Add(text.Substring(wordStart + 1, wordLength));

            return words;

        }

        void ReadTrieTreeFromTextFile(string fileName)
        {
            string text = new StreamReader(fileName).ReadToEnd();

            tree.Clear();

            List<string> words = GetWords(text);

            foreach (string word in words)
                tree.Add(word);
        }

        void WriteTrieTreeToFile(string fileName)
        {
            try
            {
                switch (Path.GetExtension(fileName))
                {
                    case ".txt":
                        tree.ToTextFile(fileName);
                        break;
                    case ".xml":
                        WriteTrieTreeToXmlFile(fileName);
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        void ReadTrieTreeFromFile(string fileName)
        {
            try
            {
                switch (Path.GetExtension(fileName))
                {
                    case ".txt":
                        ReadTrieTreeFromTextFile(fileName);
                        break;
                    case ".xml":
                        ReadTrieTreeFromXmlFile(fileName);
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

                // произошла ошибка при считывании, всё сбрасываем
                Clear();
                fileName = "";
                isSaveFile = true;
            }
        }

        private void addWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWord();
        }

        private void removeWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveWord();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void addWordToolStripButton_Click(object sender, EventArgs e)
        {
            AddWord();
        }

        private void removeWordToolStripButton_Click(object sender, EventArgs e)
        {
            RemoveWord();
        }

        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void findWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindWord();
        }

        private void findWordToolStripButton_Click(object sender, EventArgs e)
        {
            FindWord();
        }

        private void solveTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolveTask();
        }

        private void solveTaskToolStripButton_Click(object sender, EventArgs e)
        {
            SolveTask();
        }

        private void createFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void createFileToolStripButton_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private void openFileToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private void saveFileToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsFileToolStripButton_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseFile();
        }

        private void closeFileToolStripButton_Click(object sender, EventArgs e)
        {
            CloseFile();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckFileIsNotSave() == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
