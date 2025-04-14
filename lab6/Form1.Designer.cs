namespace lab6
{
    partial class Form1
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
            windowsTable = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            process = new DataGridViewTextBoxColumn();
            getWndBtn = new Button();
            titleInput = new TextBox();
            xInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            heightInput = new TextBox();
            yInput = new TextBox();
            changeBtn = new Button();
            widthInput = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)windowsTable).BeginInit();
            SuspendLayout();
            // 
            // windowsTable
            // 
            windowsTable.AllowUserToAddRows = false;
            windowsTable.AllowUserToDeleteRows = false;
            windowsTable.AllowUserToResizeColumns = false;
            windowsTable.AllowUserToResizeRows = false;
            windowsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            windowsTable.Columns.AddRange(new DataGridViewColumn[] { name, process });
            windowsTable.Location = new Point(170, 12);
            windowsTable.MultiSelect = false;
            windowsTable.Name = "windowsTable";
            windowsTable.ReadOnly = true;
            windowsTable.RowHeadersVisible = false;
            windowsTable.RowTemplate.Height = 25;
            windowsTable.Size = new Size(301, 206);
            windowsTable.TabIndex = 0;
            // 
            // name
            // 
            name.HeaderText = "Имя окна";
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 150;
            // 
            // process
            // 
            process.HeaderText = "Процесс";
            process.Name = "process";
            process.ReadOnly = true;
            process.Width = 150;
            // 
            // getWndBtn
            // 
            getWndBtn.Location = new Point(279, 240);
            getWndBtn.Name = "getWndBtn";
            getWndBtn.Size = new Size(75, 23);
            getWndBtn.TabIndex = 1;
            getWndBtn.Text = "Получить";
            getWndBtn.UseVisualStyleBackColor = true;
            getWndBtn.Click += getWndBtn_Click;
            // 
            // titleInput
            // 
            titleInput.Location = new Point(50, 12);
            titleInput.Name = "titleInput";
            titleInput.Size = new Size(100, 23);
            titleInput.TabIndex = 2;
            // 
            // xInput
            // 
            xInput.Location = new Point(50, 58);
            xInput.Name = "xInput";
            xInput.Size = new Size(100, 23);
            xInput.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 62);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 6;
            label1.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 110);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 7;
            label2.Text = "Y";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 198);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 11;
            label3.Text = "Height";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 157);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 10;
            label4.Text = "Width";
            // 
            // heightInput
            // 
            heightInput.Location = new Point(50, 195);
            heightInput.Name = "heightInput";
            heightInput.Size = new Size(100, 23);
            heightInput.TabIndex = 9;
            // 
            // yInput
            // 
            yInput.Location = new Point(50, 106);
            yInput.Name = "yInput";
            yInput.Size = new Size(100, 23);
            yInput.TabIndex = 8;
            // 
            // changeBtn
            // 
            changeBtn.Location = new Point(62, 240);
            changeBtn.Name = "changeBtn";
            changeBtn.Size = new Size(75, 23);
            changeBtn.TabIndex = 12;
            changeBtn.Text = "Изменить";
            changeBtn.UseVisualStyleBackColor = true;
            changeBtn.Click += changeBtn_Click;
            // 
            // widthInput
            // 
            widthInput.Location = new Point(50, 152);
            widthInput.Name = "widthInput";
            widthInput.Size = new Size(100, 23);
            widthInput.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 16);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 14;
            label5.Text = "Title";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 286);
            Controls.Add(label5);
            Controls.Add(widthInput);
            Controls.Add(changeBtn);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(heightInput);
            Controls.Add(yInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(xInput);
            Controls.Add(titleInput);
            Controls.Add(getWndBtn);
            Controls.Add(windowsTable);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)windowsTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView windowsTable;
        private Button getWndBtn;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn process;
        private TextBox titleInput;
        private TextBox xInput;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox heightInput;
        private TextBox yInput;
        private Button changeBtn;
        private TextBox widthInput;
        private Label label5;
    }
}