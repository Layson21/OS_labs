namespace lab4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox inputTextBox;
        private Button startButton;
        private Button pauseButton;
        private Button stopButton;
        private ComboBox priorityCombo1;
        private ComboBox priorityCombo2;
        private ComboBox priorityCombo3;
        private Label resultLabel1;
        private Label resultLabel2;
        private Label resultLabel3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            inputTextBox = new TextBox();
            startButton = new Button();
            pauseButton = new Button();
            stopButton = new Button();
            priorityCombo1 = new ComboBox();
            priorityCombo2 = new ComboBox();
            priorityCombo3 = new ComboBox();
            resultLabel1 = new Label();
            resultLabel2 = new Label();
            resultLabel3 = new Label();
            SuspendLayout();
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(56, 22);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(266, 23);
            inputTextBox.TabIndex = 0;
            inputTextBox.TextAlign = HorizontalAlignment.Center;
            inputTextBox.TextChanged += inputTextBox_TextChanged;
            // 
            // startButton
            // 
            startButton.Location = new Point(56, 231);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 1;
            startButton.Text = "Старт";
            startButton.Click += StartButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(248, 231);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(75, 23);
            pauseButton.TabIndex = 2;
            pauseButton.Text = "Пауза";
            pauseButton.Click += PauseButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(152, 231);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(75, 23);
            stopButton.TabIndex = 3;
            stopButton.Text = "Стоп";
            stopButton.Click += StopButton_Click;
            // 
            // priorityCombo1
            // 
            priorityCombo1.DropDownStyle = ComboBoxStyle.DropDownList;
            priorityCombo1.Items.AddRange(new object[] { ThreadPriority.Lowest, ThreadPriority.BelowNormal, ThreadPriority.Normal, ThreadPriority.AboveNormal, ThreadPriority.Highest });
            priorityCombo1.Location = new Point(223, 85);
            priorityCombo1.Name = "priorityCombo1";
            priorityCombo1.Size = new Size(100, 23);
            priorityCombo1.TabIndex = 4;
            priorityCombo1.SelectedIndexChanged += PriorityCombo1_SelectedIndexChanged;
            // 
            // priorityCombo2
            // 
            priorityCombo2.DropDownStyle = ComboBoxStyle.DropDownList;
            priorityCombo2.Items.AddRange(new object[] { ThreadPriority.Lowest, ThreadPriority.BelowNormal, ThreadPriority.Normal, ThreadPriority.AboveNormal, ThreadPriority.Highest });
            priorityCombo2.Location = new Point(223, 114);
            priorityCombo2.Name = "priorityCombo2";
            priorityCombo2.Size = new Size(100, 23);
            priorityCombo2.TabIndex = 5;
            priorityCombo2.SelectedIndexChanged += PriorityCombo2_SelectedIndexChanged;
            // 
            // priorityCombo3
            // 
            priorityCombo3.DropDownStyle = ComboBoxStyle.DropDownList;
            priorityCombo3.Items.AddRange(new object[] { ThreadPriority.Lowest, ThreadPriority.BelowNormal, ThreadPriority.Normal, ThreadPriority.AboveNormal, ThreadPriority.Highest });
            priorityCombo3.Location = new Point(223, 143);
            priorityCombo3.Name = "priorityCombo3";
            priorityCombo3.Size = new Size(100, 23);
            priorityCombo3.TabIndex = 6;
            priorityCombo3.SelectedIndexChanged += PriorityCombo3_SelectedIndexChanged;
            // 
            // resultLabel1
            // 
            resultLabel1.Location = new Point(56, 88);
            resultLabel1.Name = "resultLabel1";
            resultLabel1.Size = new Size(160, 25);
            resultLabel1.TabIndex = 7;
            resultLabel1.Text = "Поток 1: ";
            // 
            // resultLabel2
            // 
            resultLabel2.Location = new Point(56, 119);
            resultLabel2.Name = "resultLabel2";
            resultLabel2.Size = new Size(160, 23);
            resultLabel2.TabIndex = 8;
            resultLabel2.Text = "Поток 2: ";
            // 
            // resultLabel3
            // 
            resultLabel3.Location = new Point(56, 148);
            resultLabel3.Name = "resultLabel3";
            resultLabel3.Size = new Size(160, 23);
            resultLabel3.TabIndex = 9;
            resultLabel3.Text = "Поток 3: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 290);
            Controls.Add(inputTextBox);
            Controls.Add(startButton);
            Controls.Add(pauseButton);
            Controls.Add(stopButton);
            Controls.Add(priorityCombo1);
            Controls.Add(priorityCombo2);
            Controls.Add(priorityCombo3);
            Controls.Add(resultLabel1);
            Controls.Add(resultLabel2);
            Controls.Add(resultLabel3);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Multi-Thread Application";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}