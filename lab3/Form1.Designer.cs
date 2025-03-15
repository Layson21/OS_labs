namespace lab3
{
    partial class ExplorerApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewFiles = new ListView();
            NameElement = new ColumnHeader();
            TypeElement = new ColumnHeader();
            Size = new ColumnHeader();
            CreateFileButton = new Button();
            DeleteButton = new Button();
            CopyButton = new Button();
            InsertButton = new Button();
            CreateFolderButton = new Button();
            MoveButton = new Button();
            BackButton = new Button();
            FFTextBox = new TextBox();
            EnterButton = new Button();
            CancelButton = new Button();
            PathTextBox = new TextBox();
            GoButton = new Button();
            MoveLabel = new Label();
            EnterMoveButton = new Button();
            ChangeNameButton = new Button();
            CancelMove = new Button();
            EnterChangeButton = new Button();
            SuspendLayout();
            // 
            // ListViewFiles
            // 
            ListViewFiles.Columns.AddRange(new ColumnHeader[] { NameElement, TypeElement, Size });
            ListViewFiles.FullRowSelect = true;
            ListViewFiles.GridLines = true;
            ListViewFiles.Location = new Point(12, 32);
            ListViewFiles.Name = "ListViewFiles";
            ListViewFiles.Size = new Size(810, 348);
            ListViewFiles.TabIndex = 0;
            ListViewFiles.UseCompatibleStateImageBehavior = false;
            ListViewFiles.View = View.Details;
            ListViewFiles.ColumnWidthChanging += ListViewFiles_ColumnWidthChanging;
            ListViewFiles.ItemActivate += ListViewFiles_ItemActivate;
            ListViewFiles.MouseClick += ListViewFiles_MouseClick;
            // 
            // NameElement
            // 
            NameElement.Text = "Имя";
            NameElement.Width = 400;
            // 
            // TypeElement
            // 
            TypeElement.Text = "Тип";
            TypeElement.Width = 205;
            // 
            // Size
            // 
            Size.Text = "Размер";
            Size.Width = 205;
            // 
            // CreateFileButton
            // 
            CreateFileButton.Location = new Point(12, 415);
            CreateFileButton.Name = "CreateFileButton";
            CreateFileButton.Size = new Size(110, 23);
            CreateFileButton.TabIndex = 1;
            CreateFileButton.Text = "Создать файл";
            CreateFileButton.UseVisualStyleBackColor = true;
            CreateFileButton.Click += CreateFileButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(248, 415);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(110, 23);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // CopyButton
            // 
            CopyButton.Location = new Point(364, 415);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(110, 23);
            CopyButton.TabIndex = 3;
            CopyButton.Text = "Копировать";
            CopyButton.UseVisualStyleBackColor = true;
            CopyButton.Click += CopyButton_Click;
            // 
            // InsertButton
            // 
            InsertButton.Location = new Point(480, 415);
            InsertButton.Name = "InsertButton";
            InsertButton.Size = new Size(110, 23);
            InsertButton.TabIndex = 4;
            InsertButton.Text = "Вставить";
            InsertButton.UseVisualStyleBackColor = true;
            InsertButton.Click += InsertButton_Click;
            // 
            // CreateFolderButton
            // 
            CreateFolderButton.Location = new Point(132, 415);
            CreateFolderButton.Name = "CreateFolderButton";
            CreateFolderButton.Size = new Size(110, 23);
            CreateFolderButton.TabIndex = 5;
            CreateFolderButton.Text = "Создать папку";
            CreateFolderButton.UseVisualStyleBackColor = true;
            CreateFolderButton.Click += CreateFolderButton_Click;
            // 
            // MoveButton
            // 
            MoveButton.Location = new Point(596, 415);
            MoveButton.Name = "MoveButton";
            MoveButton.Size = new Size(110, 23);
            MoveButton.TabIndex = 6;
            MoveButton.Text = "Переместить";
            MoveButton.UseVisualStyleBackColor = true;
            MoveButton.Click += MoveButton_Click;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 3);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(51, 23);
            BackButton.TabIndex = 8;
            BackButton.Text = "Назад";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // FFTextBox
            // 
            FFTextBox.Location = new Point(132, 385);
            FFTextBox.Name = "FFTextBox";
            FFTextBox.Size = new Size(574, 23);
            FFTextBox.TabIndex = 9;
            FFTextBox.Visible = false;
            // 
            // EnterButton
            // 
            EnterButton.Location = new Point(712, 385);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(110, 23);
            EnterButton.TabIndex = 10;
            EnterButton.Text = "Создать";
            EnterButton.UseVisualStyleBackColor = true;
            EnterButton.Visible = false;
            EnterButton.Click += EnterButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(12, 385);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(110, 23);
            CancelButton.TabIndex = 11;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Visible = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // PathTextBox
            // 
            PathTextBox.Location = new Point(69, 3);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(637, 23);
            PathTextBox.TabIndex = 12;
            PathTextBox.KeyDown += PathTextBox_KeyDown;
            // 
            // GoButton
            // 
            GoButton.Location = new Point(712, 3);
            GoButton.Name = "GoButton";
            GoButton.Size = new Size(110, 23);
            GoButton.TabIndex = 13;
            GoButton.Text = "Перейти";
            GoButton.UseVisualStyleBackColor = true;
            GoButton.Click += GoButton_Click;
            // 
            // MoveLabel
            // 
            MoveLabel.AutoSize = true;
            MoveLabel.Location = new Point(350, 388);
            MoveLabel.Name = "MoveLabel";
            MoveLabel.Size = new Size(124, 15);
            MoveLabel.TabIndex = 14;
            MoveLabel.Text = "Укажите директорию";
            MoveLabel.Visible = false;
            // 
            // EnterMoveButton
            // 
            EnterMoveButton.Location = new Point(420, 415);
            EnterMoveButton.Name = "EnterMoveButton";
            EnterMoveButton.Size = new Size(105, 23);
            EnterMoveButton.TabIndex = 15;
            EnterMoveButton.Text = "Переместить";
            EnterMoveButton.UseVisualStyleBackColor = true;
            EnterMoveButton.Visible = false;
            EnterMoveButton.Click += EnterMoveButton_Click;
            // 
            // ChangeNameButton
            // 
            ChangeNameButton.Location = new Point(712, 415);
            ChangeNameButton.Name = "ChangeNameButton";
            ChangeNameButton.Size = new Size(110, 23);
            ChangeNameButton.TabIndex = 16;
            ChangeNameButton.Text = "Переименовать";
            ChangeNameButton.UseVisualStyleBackColor = true;
            ChangeNameButton.Click += ChangeNameButton_Click;
            // 
            // CancelMove
            // 
            CancelMove.Location = new Point(304, 415);
            CancelMove.Name = "CancelMove";
            CancelMove.Size = new Size(110, 23);
            CancelMove.TabIndex = 17;
            CancelMove.Text = "Отмена";
            CancelMove.UseVisualStyleBackColor = true;
            CancelMove.Visible = false;
            CancelMove.Click += CancelButton_Click;
            // 
            // EnterChangeButton
            // 
            EnterChangeButton.Location = new Point(712, 385);
            EnterChangeButton.Name = "EnterChangeButton";
            EnterChangeButton.Size = new Size(110, 23);
            EnterChangeButton.TabIndex = 18;
            EnterChangeButton.Text = "Переименовать";
            EnterChangeButton.UseVisualStyleBackColor = true;
            EnterChangeButton.Visible = false;
            EnterChangeButton.Click += EnterChangeButton_Click;
            // 
            // ExplorerApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(834, 450);
            Controls.Add(EnterChangeButton);
            Controls.Add(CancelMove);
            Controls.Add(ChangeNameButton);
            Controls.Add(EnterMoveButton);
            Controls.Add(MoveLabel);
            Controls.Add(GoButton);
            Controls.Add(PathTextBox);
            Controls.Add(CancelButton);
            Controls.Add(EnterButton);
            Controls.Add(FFTextBox);
            Controls.Add(BackButton);
            Controls.Add(MoveButton);
            Controls.Add(CreateFolderButton);
            Controls.Add(InsertButton);
            Controls.Add(CopyButton);
            Controls.Add(DeleteButton);
            Controls.Add(CreateFileButton);
            Controls.Add(ListViewFiles);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ExplorerApp";
            Text = "ExplorerApp";
            Load += ExplorerApp_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView ListViewFiles;
        private Button CreateFileButton;
        private Button DeleteButton;
        private Button CopyButton;
        private Button InsertButton;
        private Button CreateFolderButton;
        private Button MoveButton;
        private Button BackButton;
        private TextBox FFTextBox;
        private Button EnterButton;
        private Button CancelButton;
        private ColumnHeader NameElement;
        private ColumnHeader Size;
        private ColumnHeader TypeElement;
        private TextBox PathTextBox;
        private Button GoButton;
        private Label MoveLabel;
        private Button EnterMoveButton;
        private Button ChangeNameButton;
        private Button CancelMove;
        private Button EnterChangeButton;
    }
}