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

namespace WindowsFormsApp1
{
    public partial class question_1 : Form
    {
        public question_1()
        {
            InitializeComponent();
            this.Resize += new EventHandler(this.alignment_elements);
            alignment_elements(this, EventArgs.Empty);
            this.comboBox1.SelectedIndex = 2;
            this.comboBox2.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            double value;
            if (double.TryParse(this.textBox1.Text, out value))
            {
                if (this.comboBox2.SelectedIndex < 4)
                {
                    value = value * Math.PI / 180;
                    if (this.comboBox2.SelectedIndex == 0) 
                    {
                        this.textBox2.Text = Math.Round(Math.Sin(value), 4).ToString();
                    }
                    if (this.comboBox2.SelectedIndex == 1)
                    {
                        this.textBox2.Text = Math.Round(Math.Cos(value), 4).ToString();
                    }
                    if (this.comboBox2.SelectedIndex == 2)
                    {
                        this.textBox2.Text = Math.Round(Math.Tan(value), 4).ToString();
                    }
                    if (this.comboBox2.SelectedIndex == 3)
                    {
                        if (Math.Tan(value) == 0)
                        {
                            this.textBox2.Text = "Infinity";
                        }
                        else
                        {
                            this.textBox2.Text = Math.Round(1f / Math.Tan(value), 4).ToString();
                        }
                    }
                }
                else
                {
                    if ((this.comboBox2.SelectedIndex == 4) || (this.comboBox2.SelectedIndex == 5))
                    {
                        if (value >= -1 && value <= 1)
                        {
                            if (this.comboBox2.SelectedIndex == 4)
                            {
                                this.textBox2.Text = Math.Round(Math.Asin(value) / Math.PI * 180, 4).ToString();
                            }
                            if (this.comboBox2.SelectedIndex == 5)
                            {
                                this.textBox2.Text = Math.Round(Math.Acos(value) / Math.PI * 180, 4).ToString();
                            }
                        }
                        else
                        {
                            this.textBox2.Text = "Value Error";
                        }
                    }
                    if (this.comboBox2.SelectedIndex == 6)
                    {
                        this.textBox2.Text = Math.Round(Math.Atan(value) / Math.PI * 180, 4).ToString();
                    }
                    if (this.comboBox2.SelectedIndex == 7)
                    {
                        this.textBox2.Text = Math.Round((Math.PI / 2 - Math.Atan(value)) / Math.PI * 180, 4).ToString();
                    }
                }

            }
            else
            {
                this.textBox2.Text = "Input Error";
            }
        }
        private void alignment_elements(object sender, EventArgs e)
        {
            float ratio = (float)this.Width / 854f;

            float initial_button1_width = 130f;
            float initial_button1_heigth = 60f;
            float initial_font1_size = 16f;
            float initial_font2_size = 11f;
            float initial_textBox_height = 40f;
            float initial_textBox_width = 130f;
            float comboBox_width = 90f;

            button1.Width = (int)(initial_button1_width * ratio);
            button1.Height = (int)(initial_button1_heigth * ratio);
            textBox1.Width = (int)(initial_textBox_width * ratio);
            textBox1.Height = (int)(initial_textBox_height * ratio);
            textBox2.Width = (int)(initial_textBox_width * ratio);
            textBox2.Height = (int)(initial_textBox_height * ratio);
            comboBox1.Width = (int)(comboBox_width * ratio);
            comboBox2.Width = (int)(comboBox_width * ratio);

            button1.Font = new Font(button1.Font.FontFamily, (int)(initial_font2_size * ratio));
            label1.Font = new Font(label1.Font.FontFamily, (int)(initial_font1_size * ratio));
            label2.Font = new Font(label2.Font.FontFamily, (int)(initial_font1_size * ratio));
            textBox1.Font = new Font(textBox1.Font.FontFamily, (int)(initial_font2_size * ratio));
            textBox2.Font = new Font(textBox2.Font.FontFamily, (int)(initial_font2_size * ratio));
            comboBox1.Font = new Font(comboBox1.Font.FontFamily, (int)(initial_font2_size * ratio));
            comboBox2.Font = new Font(comboBox2.Font.FontFamily, (int)(initial_font2_size * ratio));

            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            label1.Left = this.ClientSize.Width / 4 - label1.Width / 2;
            label2.Left = this.ClientSize.Width / 4 * 3 - label2.Width / 2;
            textBox1.Left = this.ClientSize.Width / 4 - textBox1.Width / 2;
            textBox2.Left = this.ClientSize.Width / 4 * 3 - textBox2.Width / 2;

            button1.Top = (this.ClientSize.Height - button1.Height) / 6 * 5;
            label1.Top = (this.ClientSize.Height - label1.Height) / 6;
            label2.Top = (this.ClientSize.Height - label2.Height) / 6;
            textBox1.Top = (this.ClientSize.Height - textBox1.Height) / 6 * 2;
            textBox2.Top = (this.ClientSize.Height - textBox2.Height) / 6 * 2;
             

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
            this.Location = new Point(0,0);
        }
    }
}
