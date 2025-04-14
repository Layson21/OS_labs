namespace lab5
{
    partial class Lab5Form
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
            UrlTextBox = new TextBox();
            GoButton = new Button();
            SuspendLayout();
            // 
            // UrlTextBox
            // 
            UrlTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UrlTextBox.Location = new Point(12, 93);
            UrlTextBox.Name = "UrlTextBox";
            UrlTextBox.Size = new Size(427, 29);
            UrlTextBox.TabIndex = 0;
            // 
            // GoButton
            // 
            GoButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            GoButton.Location = new Point(155, 166);
            GoButton.Name = "GoButton";
            GoButton.Size = new Size(132, 37);
            GoButton.TabIndex = 1;
            GoButton.Text = "Перейти";
            GoButton.UseVisualStyleBackColor = true;
            GoButton.Click += GoButton_Click;
            // 
            // Lab5Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 286);
            Controls.Add(GoButton);
            Controls.Add(UrlTextBox);
            Name = "Lab5Form";
            Text = "Переходник";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UrlTextBox;
        private Button GoButton;
    }
}