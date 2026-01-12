using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numericup_and_down
{
    public partial class Form1 : Form
    {
        private string path = System.AppDomain.CurrentDomain.BaseDirectory + "//images//";
        private double castig = 100;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(path + "1.png");
            pictureBox2.Image = Image.FromFile(path + "1.png");
            pictureBox3.Image = Image.FromFile(path + "1.png");
            numericUpDown1.Value = 5;
            int y = 0;
            label2.Text = $"Castig: {y}";

            label1.Text = $"Total: {castig}";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double x = (double)numericUpDown1.Value;

            if (x <= 0)
            {
                MessageBox.Show("Miza trebuie sa fie mai mare ca 0");
                return; 
            }

            if (x > castig)
            {
                MessageBox.Show("Nu ai destui bani. Pune o miza mai mica");
                return; 
            }

            if (castig <= 0)
            {
                MessageBox.Show("Ai cheltuit toti banii");
                return;
            }

            
            int nr1 = random.Next(2, 8);
            int nr2 = random.Next(2, 8);
            int nr3 = random.Next(2, 8);

            pictureBox1.Image = Image.FromFile(path + $"{nr1}.png");
            pictureBox2.Image = Image.FromFile(path + $"{nr2}.png");
            pictureBox3.Image = Image.FromFile(path + $"{nr3}.png");

            castig -= x;

            double y; 
            if (nr1 == nr2 && nr2 == nr3)
            {
                y = x * 6;
                castig += y;
            }
            else if ((nr1 == nr2 && nr2 != nr3) || (nr2 == nr3 && nr2 != nr1) || (nr1 == nr3 && nr1 != nr2))
            {
                y = x * 1.5;
                castig += y;
            }
            else
            {
                y = x * 0.2;
                castig += y;
            }

            label2.Text = $"Castig: {y}";
            label1.Text = $"Total: {castig}";
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int x = (int)numericUpDown1.Value;

            if (x > castig)
                MessageBox.Show("Ai prea putini bani");
        }
    }
}
