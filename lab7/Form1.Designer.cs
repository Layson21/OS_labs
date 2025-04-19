namespace lab7
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
            stopBtn = new Button();
            startBtn = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // stopBtn
            // 
            stopBtn.Enabled = false;
            stopBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            stopBtn.Location = new Point(95, 134);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(154, 57);
            stopBtn.TabIndex = 1;
            stopBtn.Text = "Stop";
            stopBtn.UseVisualStyleBackColor = true;
            stopBtn.Click += stopBtn_Click;
            // 
            // startBtn
            // 
            startBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            startBtn.Location = new Point(95, 60);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(154, 57);
            startBtn.TabIndex = 2;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(234, 210);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(0, 23);
            textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 245);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(startBtn);
            Controls.Add(stopBtn);
            Name = "Form1";
            Text = "Hooker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button stopBtn;
        private Button startBtn;
        private Label label1;
        private TextBox textBox1;
    }
}