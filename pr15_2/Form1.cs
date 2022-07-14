using System;
using System.Drawing;
using System.Windows.Forms;

namespace pr15_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int counter = 0;
        private bool pressI = false;
        private bool pressX = false;
        
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (button1.Location.Y > 4)
            {
                button1.Top -= 10;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (ModifierKeys == Keys.Shift)
            {
                button3.Width -= 3;
                button3.Height -= 3;
            }
            else if (ModifierKeys == Keys.Control)
            {
                if (counter == 0)
                {
                    button3.Font = new Font("Times", 10, FontStyle.Bold);
                    counter++;
                }

                else if (counter == 1)
                {
                    button3.Font = new Font("Times", 10, FontStyle.Italic);
                    counter++;
                }
                else if (counter == 2)
                {
                    button3.Font = new Font("Times", 10, FontStyle.Underline);
                    counter++;
                }
                else if (counter == 3)
                {
                    button3.Font = new Font("Times", 10, FontStyle.Regular);
                    counter -= 3;
                }
            }
            else
            {
                button3.Width += 3;
                button3.Height += 3;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ControlBox = !ControlBox;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Alt && pressI) 
                {
                    button1.Top = button2.Top;
                    button2.Enabled = false;
                    button1.Enabled = true;
                    button3.Width = 88;
                    button3.Height = 34;
                    button3.Font = new Font("Times", 10, FontStyle.Regular);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
                pressI = true;
            if (e.KeyCode == Keys.X)
            {
                pressX = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
                pressI = false;
            if (e.KeyCode == Keys.X)
            {
                pressX = false;
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Alt && pressX)
                {
                    this.Close();
                }
            }
        }

        private void buttons_MouseLeave(object sender, EventArgs e)
        {
            ButtonName.Text = "";
            ButtonDesc.Text = "";
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            ButtonName.Text = "Кнопка 1";
            ButtonDesc.Text = "прячет / показывает 2-ю;";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            ButtonName.Text = "Кнопка 2";
            ButtonDesc.Text = "сдвигает первую кнопку на 10 пикселей вверх;";
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            ButtonName.Text = "Кнопка 3";
            ButtonDesc.Text = $"(1-сама по себе, 2 - с Shift, 3 - c Ctrl){Environment.NewLine} 1-увеличивает, 2-уменьшает, 3-переключает по кругу (из 3-х) шрифты на форме;";
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            ButtonName.Text = "Кнопка 4";
            ButtonDesc.Text = "вкл./выкл. системную кнопку;";
        }
    }
}
