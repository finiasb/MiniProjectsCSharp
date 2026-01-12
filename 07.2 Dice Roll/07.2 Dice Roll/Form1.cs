using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07._2_Dice_Roll
{
    public partial class Form1 : Form
    {
        private int scor = -1;

        private Random random = new Random();   
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int primul = random.Next(1, 7);
            int alDoilea = random.Next(1, 7);

            for(int i = 1; i <= 6; i++)
            {
                string path1 = System.AppDomain.CurrentDomain.BaseDirectory + $@"Images\{random.Next(1, 7)}.png";
                string path2 = System.AppDomain.CurrentDomain.BaseDirectory + $@"Images\{random.Next(1, 7)}.png";
                pictureBox1.Image = Image.FromFile(path1);
                pictureBox2.Image = Image.FromFile(path2);
                await Task.Delay(250);
            }

            string path3 = System.AppDomain.CurrentDomain.BaseDirectory + $@"Images\{primul}.png";
            string path4 = System.AppDomain.CurrentDomain.BaseDirectory + $@"Images\{alDoilea}.png";
            pictureBox1.Image = Image.FromFile(path3);
            pictureBox2.Image = Image.FromFile(path4);
            int total = primul + alDoilea;
            scor = total;
            this.Invalidate();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (scor >= 0)
            {
                string mesaj = "SCOR " + scor;
                using (Font fontMesaj = new Font("Arial", 36))
                using (SolidBrush sb = new SolidBrush(Color.Coral))
                {
                    e.Graphics.DrawString(mesaj, fontMesaj, sb, 25,  300);
                }
            }
        }

    }
}
