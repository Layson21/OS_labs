namespace lab8
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button sendFileButton;

        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.sendFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // listBox1
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Size = new System.Drawing.Size(560, 304);

            // textBox1
            this.textBox1.Location = new System.Drawing.Point(12, 322);
            this.textBox1.Size = new System.Drawing.Size(460, 23);

            // sendButton
            this.sendButton.Location = new System.Drawing.Point(478, 322);
            this.sendButton.Size = new System.Drawing.Size(94, 23);
            this.sendButton.Text = "Send";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);

            // sendFileButton
            this.sendFileButton.Location = new System.Drawing.Point(12, 351);
            this.sendFileButton.Size = new System.Drawing.Size(94, 23);
            this.sendFileButton.Text = "Send File";
            this.sendFileButton.Click += new System.EventHandler(this.sendFileButton_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(584, 391);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendFileButton);
            this.Name = "Form1";
            this.Text = "LAN Chat";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}