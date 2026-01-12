using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timp
{
    public partial class Anul : Form
    {
        public Anul()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Completează TOATE câmpurile!");
            }
            else if (!textBox1.Text.All(char.IsDigit) || !textBox2.Text.All(char.IsDigit) || !textBox3.Text.All(char.IsDigit))
            {
                MessageBox.Show("Introdu doar cifre în toate câmpurile!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                Form1 form = new Form1(textBox1.Text, textBox2.Text, textBox3.Text);
                this.Hide();
                form.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
