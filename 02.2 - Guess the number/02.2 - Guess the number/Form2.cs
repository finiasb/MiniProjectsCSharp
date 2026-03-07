using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xaml.Permissions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GuessTheNumber
{
    public partial class Form2 : Form
    {
        private int numarRandom;

        public Form2(int x)
        {
            InitializeComponent();
            numarRandom = x;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int numar;
            if (int.TryParse(textBox1.Text, out numar))
            {
                numar = Int32.Parse(textBox1.Text);
                if (numar > numarRandom)
                {
                    MessageBox.Show("incercati un numar mai mic");
                    textBox1.Clear();
                }
                else if (numar < numarRandom)
                {
                    MessageBox.Show("incercati un numar mai mare");
                    textBox1.Clear();
                }
                else if (numar == numarRandom)
                {
                    MessageBox.Show($"ati ghicit numarul corect: {numarRandom}");
                    textBox1.Clear();
                    this.Hide();
                    Form1 from = new Form1();
                    from.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("introduceti un numar");
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
