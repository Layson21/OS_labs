namespace kr1
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SelectLabel = new Label();
            SelectDirectoryButton = new Button();
            SelectDirectoryDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // SelectLabel
            // 
            SelectLabel.AutoSize = true;
            SelectLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            SelectLabel.Location = new Point(79, 72);
            SelectLabel.Name = "SelectLabel";
            SelectLabel.Size = new Size(160, 28);
            SelectLabel.TabIndex = 0;
            SelectLabel.Text = "Выберите папку";
            // 
            // SelectDirectoryButton
            // 
            SelectDirectoryButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SelectDirectoryButton.Location = new Point(98, 103);
            SelectDirectoryButton.Name = "SelectDirectoryButton";
            SelectDirectoryButton.Size = new Size(124, 34);
            SelectDirectoryButton.TabIndex = 1;
            SelectDirectoryButton.Text = "Выбрать";
            SelectDirectoryButton.UseVisualStyleBackColor = true;
            SelectDirectoryButton.Click += SelectDirectoryButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 218);
            Controls.Add(SelectDirectoryButton);
            Controls.Add(SelectLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Удаление папки";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label SelectLabel;
        private Button SelectDirectoryButton;
        private FolderBrowserDialog SelectDirectoryDialog;
    }
}