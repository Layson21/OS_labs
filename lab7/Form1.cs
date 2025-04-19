namespace lab7
{
    public partial class Form1 : Form
    {
        public static Label label;

        public Form1()
        {
            InitializeComponent();
            label = label1;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            startBtn.Enabled = false;
            stopBtn.Enabled = true;

            Manager.Start();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            stopBtn.Enabled = false;
            startBtn.Enabled = true;
            Manager.Stop();
        }
    }
}