using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WindowsFormsApp1
{
    public partial class question_3 : Form
    {
        public question_3()
        {
            InitializeComponent();
            this.Resize += new EventHandler(this.alignment_elements);
            alignment_elements(this, EventArgs.Empty);
        }
        private void alignment_elements(object sender, EventArgs e)
        {
            float ratio = (float)this.Width / 854f;
            label1.Left = (ClientSize.Width - label1.Width) / 2;
            label1.Font = new Font(label1.Font.FontFamily, (int)(16f * ratio));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = this.button1.Location.X;
            int y = this.button1.Location.Y;
            int speed = 3;
            if ((this.button1.Location.X <= 0) && (vector[0] == -1))
            {
                vector[0] = 1;
            }
            if ((this.button1.Location.Y <= 0) && (vector[1] == -1))
            {
                vector[1] = 1;
            }
            if ((this.button1.Location.X >= ClientSize.Width-this.button1.Width) && (vector[0] == 1))
            {
                vector[0] = -1;
            }
            if ((this.button1.Location.Y >= ClientSize.Height- this.button1.Height) && (vector[1] == 1))
            {
                vector[1] = -1;
            }
            this.button1.Location = new Point(x + vector[0] * speed, y + vector[1] * speed);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            score += 1;
            label1.Text = "Счёт: " + (score).ToString();
            button1.Enabled = false;
            timer1.Stop();
            Timer restart = new Timer();
            restart.Interval = 1000; 
            restart.Tick += (s, args) =>
            {
                timer1.Start();

                Random rand = new Random();
                vector[0] = rand.Next(3) - 1;
                if (vector[0] == 0)
                {
                    vector[1] = rand.Next(2) * 2 - 1;
                }
                else
                {
                    vector[1] = rand.Next(3) - 1;
                }
                button1.Enabled = true;
                restart.Stop();
            };

            restart.Start();
        }

        private void question_3_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (vector[0] == 0)
            {
                vector[1] = rand.Next(2) * 2 - 1;
            }
            else
            {
                vector[1] = rand.Next(3) - 1;
            }
            timer1.Start();
        }

    }

}
