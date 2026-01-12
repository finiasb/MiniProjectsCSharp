using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08._3___Race
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timerSemafor;
        private System.Windows.Forms.Timer timerPrimaMasina;
        private System.Windows.Forms.Timer timerADouaMasina;
        private string path = System.AppDomain.CurrentDomain.BaseDirectory;
        private int semafor = 0;
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            int rnd1 = random.Next(4, 9);
            int rnd2 = random.Next(4, 9);
            pictureBox2.Parent = pictureBox1; 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.Parent = pictureBox1; 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.Parent = pictureBox1;
            pictureBox4.BackColor = Color.Transparent;

            timerSemafor = new System.Windows.Forms.Timer();
            timerSemafor.Interval = 500;
            timerSemafor.Tick += timerSemafor_Tick;

            timerPrimaMasina = new System.Windows.Forms.Timer();
            timerPrimaMasina.Interval = rnd1;
            timerPrimaMasina.Tick += timerPrimaMasina_Tick;

            timerADouaMasina = new System.Windows.Forms.Timer();
            timerADouaMasina.Interval = rnd2;
            timerADouaMasina.Tick += timerADouaMasina_Tick;


        }
        private int x1 = 0;
        private int x2 = 0;
        private int imagine1 = 1;
        private int imagine2 = 1;
        private void timerPrimaMasina_Tick(object sender, EventArgs e)
        {
            pictureBox2.Location = new System.Drawing.Point(x1, 320);
            x1 += 3;
            pictureBox2.Image = Image.FromFile(path + $"car1\\{imagine1}-Photoroom.png");
            imagine1++;
            if (imagine1 == 24)
                imagine1 = 1;

            if (x1 >= 712)
            {

                timerADouaMasina.Stop();
                timerPrimaMasina.Stop();
                MessageBox.Show("Masina 1 a castigat");
                Reset();
            }
        }

        private void timerADouaMasina_Tick(object sender, EventArgs e)
        {
            pictureBox3.Location = new System.Drawing.Point(x2, 360);
            x2+= 3;
            pictureBox3.Image = Image.FromFile(path + $"car2\\{imagine2}.png");
            imagine2++;
            if (imagine2 == 27)
                imagine2 = 1;

            if(x2 >= 712)
            {
                timerADouaMasina.Stop();
                timerPrimaMasina.Stop();
                MessageBox.Show("Masina 2 a castigat");
                Reset();
            }
        }
        private void Reset()
        {
            timerSemafor.Stop();
            timerPrimaMasina.Stop();
            timerADouaMasina.Stop();

            semafor = 0;
            x1 = 0;
            x2 = 0;
            imagine1 = 1;
            imagine2 = 1;

            timerPrimaMasina.Interval = random.Next(7, 15);
            timerADouaMasina.Interval = random.Next(7, 15);

            pictureBox2.Location = new Point(0, 320);
            pictureBox3.Location = new Point(0, 360);

        }

        private void timerSemafor_Tick(object sender, EventArgs e)
        {
            semafor++;
            if(semafor == 4)
            {
                semafor = 0;

                timerSemafor.Stop();
                timerPrimaMasina.Start();
                timerADouaMasina.Start();
                pictureBox4.Visible = false;
            }
            else
            {
                pictureBox4.Visible = true;
                pictureBox4.Image = Image.FromFile(path + $"semafor\\{semafor}.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerSemafor.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timerSemafor.Stop();
            timerPrimaMasina.Stop();
            timerADouaMasina.Stop();

        }
    }
}
