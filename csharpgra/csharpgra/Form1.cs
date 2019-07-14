using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpgra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int czas = 0, wylosowana = 0, trafienia = 0;

        static int Losuj(int min = 1, int max = 100)
        {
            if (min > max)
            {
                int temp = max;
                max = min;
                min = temp;
            }

            Random generator = new Random();
            return generator.Next(min, max + 1);

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            czas++;
            label8.Text = czas + " s";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                wylosowana = Losuj(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                trafienia = 0;
                label7.Text = trafienia.ToString();
                czas = 0;
                label8.Text = czas + " s";
                timer1.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
                textBox3.Enabled = true;
                button2.Enabled = true;
            }
            catch 
            {
                MessageBox.Show("Błędne dane");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int liczba = Convert.ToInt32(textBox3.Text);
                trafienia++;
                label7.Text = trafienia.ToString();
                if (wylosowana == liczba)
                {
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button1.Enabled = true;
                    textBox3.Enabled = false;
                    button2.Enabled = false;
                    timer1.Enabled = false;
                    label4.Text = "WYGRANA !";
                } else if(wylosowana > liczba)
                {
                    label4.Text = "ZA MAŁO";
                } else if(wylosowana < liczba)
                {
                    label4.Text = "ZA DUŻO";
                }
            }
            catch
            {
                MessageBox.Show("Błędne dane");
            }
        }
    }
}
