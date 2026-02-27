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

namespace _14._1_Car_race
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        double scor = 0;
        string path = System.AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox4.Top += 20;  
            pictureBox5.Top += 20;
            int x1 = rnd.Next(50, 200);
            int x2 = rnd.Next(200, 400);

            pictureBox1.Top += 20;
            pictureBox2.Top += 20;

            if (pictureBox1.Top >= this.Height)
            {
                pictureBox1.Top = pictureBox2.Top - pictureBox1.Height;
            }

            if (pictureBox2.Top >= this.Height)
            {
                pictureBox2.Top = pictureBox1.Top - pictureBox2.Height;
            }
            if (pictureBox4.Top > 500)
            {
                pictureBox4.Top = -50;
                pictureBox4.Left = x1;
                int x = rnd.Next(1, 9);
                switch (x)
                {
                    case 1:
                        pictureBox5.Image = Image.FromFile(path + "carGreen.png");
                        break;
                    case 2:
                        pictureBox5.Image = Image.FromFile(path + "carGrey.png");
                        break;
                    case 3:
                        pictureBox5.Image = Image.FromFile(path + "carOrange.png");
                        break;
                    case 4:
                        pictureBox5.Image = Image.FromFile(path + "carPink.png");
                        break;
                    case 5:
                        pictureBox5.Image = Image.FromFile(path + "carRed.png");
                        break;
                    case 6:
                        pictureBox5.Image = Image.FromFile(path + "carYellow.png");
                        break;
                    case 7:
                        pictureBox5.Image = Image.FromFile(path + "TruckBlue.png");
                        break;
                    case 8:
                        pictureBox5.Image = Image.FromFile(path + "TruckWhite.png");
                        break;
                }
            }
            if (pictureBox5.Top > 500)
            {
                pictureBox5.Top = -50;
                pictureBox5.Left = x2;
                int x = rnd.Next(1, 9);
                switch (x)
                {
                    case 1:
                        pictureBox4.Image = Image.FromFile(path + "carGreen.png");
                        break;
                    case 2:
                        pictureBox4.Image = Image.FromFile(path + "carGrey.png");
                        break;
                    case 3:
                        pictureBox4.Image = Image.FromFile(path + "carOrange.png");
                        break;
                    case 4:
                        pictureBox4.Image = Image.FromFile(path + "carPink.png");
                        break;
                    case 5:
                        pictureBox4.Image = Image.FromFile(path + "carRed.png");
                        break;
                    case 6:
                        pictureBox4.Image = Image.FromFile(path + "carYellow.png");
                        break;
                    case 7:
                        pictureBox4.Image = Image.FromFile(path + "TruckBlue.png");
                        break;
                    case 8:
                        pictureBox4.Image = Image.FromFile(path + "TruckWhite.png");
                        break;
                }
                
            }

            
            if (pictureBox3.Bounds.IntersectsWith(pictureBox4.Bounds) || pictureBox3.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                PictureBox pic = new PictureBox();
                pic.Size = new Size(30, 20);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Location = pictureBox3.Location;
                pic.Image = Image.FromFile(path + "explosion.gif");
                pic.Parent = pictureBox3;
                this.Controls.Add(pic);
                timer1.Stop();
                pictureBox6.Visible = true;
                if(scor < 200)
                {
                    pictureBox6.Image = Image.FromFile(path + "bronze.png");
                }
                else if (scor < 500)
                {
                    pictureBox6.Image = Image.FromFile(path + "silver.png");
                }
                else 
                {
                    pictureBox6.Image = Image.FromFile(path + "gold.png");
                }
            }
            scor += 1;
            label1.Text = "Scor: " + (int)scor;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && pictureBox3.Left > 40)
            {
                pictureBox3.Left -= 30;
            }
            else if (e.KeyCode == Keys.D && pictureBox3.Left < 400) 
            {
                pictureBox3.Left += 30;
            }
        }
    }
}
