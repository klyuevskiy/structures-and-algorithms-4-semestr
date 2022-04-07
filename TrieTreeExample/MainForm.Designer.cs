
namespace TrieTreeExample
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solveTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.createFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.closeFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addWordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeWordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.clearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.findWordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.solveTaskToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.wordColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wordsCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.changeToolStripMenuItem,
            this.findWordToolStripMenuItem,
            this.solveTaskToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFileToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.saveAsFileToolStripMenuItem,
            this.closeFileToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 25);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // createFileToolStripMenuItem
            // 
            this.createFileToolStripMenuItem.Name = "createFileToolStripMenuItem";
            this.createFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.createFileToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.createFileToolStripMenuItem.Text = "Создать";
            this.createFileToolStripMenuItem.Click += new System.EventHandler(this.createFileToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.openFileToolStripMenuItem.Text = "Открыть";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.saveFileToolStripMenuItem.Text = "Сохранить";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // saveAsFileToolStripMenuItem
            // 
            this.saveAsFileToolStripMenuItem.Name = "saveAsFileToolStripMenuItem";
            this.saveAsFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.saveAsFileToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.saveAsFileToolStripMenuItem.Text = "Сохранить как";
            this.saveAsFileToolStripMenuItem.Click += new System.EventHandler(this.saveAsFileToolStripMenuItem_Click);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.closeFileToolStripMenuItem.Text = "Закрыть";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeFileToolStripMenuItem_Click);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWordToolStripMenuItem,
            this.removeWordToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(129, 25);
            this.changeToolStripMenuItem.Text = "Редактировать";
            // 
            // addWordToolStripMenuItem
            // 
            this.addWordToolStripMenuItem.Name = "addWordToolStripMenuItem";
            this.addWordToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.addWordToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.addWordToolStripMenuItem.Text = "Добавить слово";
            this.addWordToolStripMenuItem.Click += new System.EventHandler(this.addWordToolStripMenuItem_Click);
            // 
            // removeWordToolStripMenuItem
            // 
            this.removeWordToolStripMenuItem.Name = "removeWordToolStripMenuItem";
            this.removeWordToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.removeWordToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.removeWordToolStripMenuItem.Text = "Удалить слово";
            this.removeWordToolStripMenuItem.Click += new System.EventHandler(this.removeWordToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.clearToolStripMenuItem.Text = "Очистить";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // findWordToolStripMenuItem
            // 
            this.findWordToolStripMenuItem.Name = "findWordToolStripMenuItem";
            this.findWordToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.findWordToolStripMenuItem.Size = new System.Drawing.Size(66, 25);
            this.findWordToolStripMenuItem.Text = "Поиск";
            this.findWordToolStripMenuItem.Click += new System.EventHandler(this.findWordToolStripMenuItem_Click);
            // 
            // solveTaskToolStripMenuItem
            // 
            this.solveTaskToolStripMenuItem.Name = "solveTaskToolStripMenuItem";
            this.solveTaskToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.solveTaskToolStripMenuItem.Size = new System.Drawing.Size(73, 25);
            this.solveTaskToolStripMenuItem.Text = "Задача";
            this.solveTaskToolStripMenuItem.Click += new System.EventHandler(this.solveTaskToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFileToolStripButton,
            this.openFileToolStripButton,
            this.saveFileToolStripButton,
            this.saveAsFileToolStripButton,
            this.closeFileToolStripButton,
            this.addWordToolStripButton,
            this.removeWordToolStripButton,
            this.clearToolStripButton,
            this.findWordToolStripButton,
            this.solveTaskToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 29);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(652, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // createFileToolStripButton
            // 
            this.createFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.createFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("createFileToolStripButton.Image")));
            this.createFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createFileToolStripButton.Name = "createFileToolStripButton";
            this.createFileToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.createFileToolStripButton.Text = "Создать файл";
            this.createFileToolStripButton.Click += new System.EventHandler(this.createFileToolStripButton_Click);
            // 
            // openFileToolStripButton
            // 
            this.openFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openFileToolStripButton.Image")));
            this.openFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileToolStripButton.Name = "openFileToolStripButton";
            this.openFileToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.openFileToolStripButton.Text = "Открыть файл";
            this.openFileToolStripButton.Click += new System.EventHandler(this.openFileToolStripButton_Click);
            // 
            // saveFileToolStripButton
            // 
            this.saveFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveFileToolStripButton.Image")));
            this.saveFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFileToolStripButton.Name = "saveFileToolStripButton";
            this.saveFileToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.saveFileToolStripButton.Text = "Сохранить файл";
            this.saveFileToolStripButton.Click += new System.EventHandler(this.saveFileToolStripButton_Click);
            // 
            // saveAsFileToolStripButton
            // 
            this.saveAsFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAsFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAsFileToolStripButton.Image")));
            this.saveAsFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsFileToolStripButton.Name = "saveAsFileToolStripButton";
            this.saveAsFileToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.saveAsFileToolStripButton.Text = "Сохранить файл как";
            this.saveAsFileToolStripButton.Click += new System.EventHandler(this.saveAsFileToolStripButton_Click);
            // 
            // closeFileToolStripButton
            // 
            this.closeFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("closeFileToolStripButton.Image")));
            this.closeFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeFileToolStripButton.Name = "closeFileToolStripButton";
            this.closeFileToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.closeFileToolStripButton.Text = "Закрыть файл";
            this.closeFileToolStripButton.Click += new System.EventHandler(this.closeFileToolStripButton_Click);
            // 
            // addWordToolStripButton
            // 
            this.addWordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addWordToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addWordToolStripButton.Image")));
            this.addWordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addWordToolStripButton.Name = "addWordToolStripButton";
            this.addWordToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.addWordToolStripButton.Text = "Добавить слово";
            this.addWordToolStripButton.Click += new System.EventHandler(this.addWordToolStripButton_Click);
            // 
            // removeWordToolStripButton
            // 
            this.removeWordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeWordToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeWordToolStripButton.Image")));
            this.removeWordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeWordToolStripButton.Name = "removeWordToolStripButton";
            this.removeWordToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.removeWordToolStripButton.Text = "Удалить слово";
            this.removeWordToolStripButton.Click += new System.EventHandler(this.removeWordToolStripButton_Click);
            // 
            // clearToolStripButton
            // 
            this.clearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearToolStripButton.Image")));
            this.clearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearToolStripButton.Name = "clearToolStripButton";
            this.clearToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.clearToolStripButton.Text = "Очистить";
            this.clearToolStripButton.Click += new System.EventHandler(this.clearToolStripButton_Click);
            // 
            // findWordToolStripButton
            // 
            this.findWordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findWordToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("findWordToolStripButton.Image")));
            this.findWordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findWordToolStripButton.Name = "findWordToolStripButton";
            this.findWordToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.findWordToolStripButton.Text = "Найти слово";
            this.findWordToolStripButton.Click += new System.EventHandler(this.findWordToolStripButton_Click);
            // 
            // solveTaskToolStripButton
            // 
            this.solveTaskToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.solveTaskToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("solveTaskToolStripButton.Image")));
            this.solveTaskToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solveTaskToolStripButton.Name = "solveTaskToolStripButton";
            this.solveTaskToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.solveTaskToolStripButton.Text = "Решить задачу";
            this.solveTaskToolStripButton.Click += new System.EventHandler(this.solveTaskToolStripButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 68);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(652, 370);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(316, 370);
            this.treeView1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Текстовые файлы (.*txt)|*.txt|XML файлы (*.xml)|*.xml";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Текстовые файлы (.*txt)|*.txt|XML файлы (*.xml)|*.xml";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wordColumn,
            this.wordsCountColumn});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(332, 370);
            this.dataGridView1.TabIndex = 0;
            // 
            // wordColumn
            // 
            this.wordColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.wordColumn.HeaderText = "Слово";
            this.wordColumn.Name = "wordColumn";
            this.wordColumn.ReadOnly = true;
            // 
            // wordsCountColumn
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordsCountColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.wordsCountColumn.HeaderText = "Количество слов";
            this.wordsCountColumn.Name = "wordsCountColumn";
            this.wordsCountColumn.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 438);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Trie Tree example";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solveTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton createFileToolStripButton;
        private System.Windows.Forms.ToolStripButton openFileToolStripButton;
        private System.Windows.Forms.ToolStripButton saveFileToolStripButton;
        private System.Windows.Forms.ToolStripButton saveAsFileToolStripButton;
        private System.Windows.Forms.ToolStripButton closeFileToolStripButton;
        private System.Windows.Forms.ToolStripButton addWordToolStripButton;
        private System.Windows.Forms.ToolStripButton removeWordToolStripButton;
        private System.Windows.Forms.ToolStripButton clearToolStripButton;
        private System.Windows.Forms.ToolStripButton findWordToolStripButton;
        private System.Windows.Forms.ToolStripButton solveTaskToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn wordColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wordsCountColumn;
    }
}

