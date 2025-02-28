using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class question_2 : Form
    {
        public question_2()
        {
            InitializeComponent();
            this.Resize += new EventHandler(this.alignment_elements);
            this.button1.MouseEnter += new EventHandler(this.button_MouseEnter);
            this.button2.MouseEnter += new EventHandler(this.button_MouseEnter);
            this.button1.MouseLeave += new EventHandler(this.button_MouseLeave);
            this.button2.MouseLeave += new EventHandler(this.button_MouseLeave);
            alignment_elements(this, EventArgs.Empty);
            this.comboBox1.SelectedIndex = 2;
        }
        private void alignment_elements(object sender, EventArgs e)
        {
            float ratio = (float)this.Width / 854f;
            float comboBox_width = 90f;
            float initial_button_width = 220f;
            float initial_button_heigth = 140f;
            float initial_button_width1 = 100f;
            float initial_button_heigth1 = 26f;
            float initial_font1_size = 30f;
            float initial_font2_size = 11f;

            comboBox1.Width = (int)(comboBox_width * ratio);
            button1.Width = (int)(initial_button_width * ratio);
            button1.Height = (int)(initial_button_heigth * ratio);
            button2.Width = (int)(initial_button_width * ratio);
            button2.Height = (int)(initial_button_heigth * ratio);
            button3.Width = (int)(initial_button_width1 * ratio);
            button3.Height = (int)(initial_button_heigth1 * ratio);

            button1.Font = new Font(button1.Font.FontFamily, (int)(initial_font1_size * ratio));
            button2.Font = new Font(button2.Font.FontFamily, (int)(initial_font1_size * ratio));
            button3.Font = new Font(button3.Font.FontFamily, (int)(initial_font2_size * ratio));
            comboBox1.Font = new Font(comboBox1.Font.FontFamily, (int)(initial_font2_size * ratio));

            button1.Left = (this.ClientSize.Width - button1.Width) / 4;
            button2.Left = (this.ClientSize.Width - button2.Width) / 4 * 3;
            button3.Left = (this.ClientSize.Width - button3.Width) / 2;

            button1.Top = (this.ClientSize.Height - button1.Height) / 2;
            button2.Top = (this.ClientSize.Height - button2.Height) / 2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                this.Width = 1920;
                this.Height = 1080;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                this.Width = 1280;
                this.Height = 720;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                this.Width = 854;
                this.Height = 480;
            }
            this.Location = new Point(0, 0);
        }
        private void button_MouseEnter(object sender, EventArgs e) 
        {
            Button button = sender as Button;
            button.Text = "Пришел";
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Text = "Ушел";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form question_3 = new question_3();
            question_3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
