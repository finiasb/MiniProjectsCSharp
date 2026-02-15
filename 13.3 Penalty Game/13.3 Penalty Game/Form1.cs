using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13._3_Penalty_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = System.AppDomain.CurrentDomain.BaseDirectory;
        double ballX, ballY;
        double targetX, targetY;
        double dirX, dirY;
        double speed = 16;   
        bool moving = false;
        int scor = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!moving) return;

            double ballDistance = Math.Sqrt((targetX - ballX) * (targetX - ballX) + (targetY - ballY) * (targetY - ballY));

            if (ballDistance > 10)
            {
                ballX += dirX * speed;
                ballY += dirY * speed;
                pictureBox7.Location = new Point((int)ballX, (int)ballY);
            }


            double keeperDistance = Math.Sqrt((keeperTargetX - keeperX) * (keeperTargetX - keeperX) + (keeperTargetY - keeperY) * (keeperTargetY - keeperY));

            if (keeperDistance > 10)
            {
                keeperX += dirXKeeper * speed;
                keeperY += dirYKeeper * speed;
                pictureBox1.Location = new Point((int)keeperX, (int)keeperY);
            }
            if (ballDistance <= 10 && keeperDistance <= 10)
            {
                timer1.Stop();
                moving = false;
            }

            if (pictureBox1.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                timer1.Stop();
                moving = false;
                scor++;
                label1.Text = "Scor: " + scor;
                MessageBox.Show("APĂRAT!");
            }
        }
        double keeperX, keeperY;

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox7.Location = new Point(400, 470);
            pictureBox1.Location = new Point(400, 169);
            pictureBox1.Image = Image.FromFile(path + "stand-small.png");
        }

        double keeperTargetX, keeperTargetY;
        double dirYKeeper, dirXKeeper;
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PictureBox target = (PictureBox)sender;

            ballX = pictureBox7.Left;
            ballY = pictureBox7.Top;

            targetX = target.Left;
            targetY = target.Top;

            double deltaX = targetX - ballX;
            double deltaY = targetY - ballY;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            dirX = deltaX / distance;
            dirY = deltaY / distance;

            moving = true;

            Random rnd = new Random();
            int x = rnd.Next(1, 5);

            if(x == 1)
            {
                pictureBox1.Image = Image.FromFile(path + "left-save-small.png");
                keeperTargetX = 190;
                keeperTargetY = 215;
            }
            else if(x == 2)
            {
                pictureBox1.Image = Image.FromFile(path + "right-save-small.png");
                keeperTargetX = 645;
                keeperTargetY = 215;
            }
            else if (x == 3)
            {
                pictureBox1.Image = Image.FromFile(path + "top-left-save-small.png");
                keeperTargetX = 190;  
                keeperTargetY = 60;
            }
            else if (x == 4)
            {
                pictureBox1.Image = Image.FromFile(path + "top-right-save-small.png");
                keeperTargetX = 400;
                keeperTargetY = 60;
            }
            else if (x == 5)
            {
                pictureBox1.Image = Image.FromFile(path + "top-save-small.png");
                keeperTargetX = 625;
                keeperTargetY = 60;
            }

            keeperX = pictureBox1.Left;
            keeperY = pictureBox1.Top;

            double deltaXkeeper = keeperTargetX - keeperX;
            double deltaYkeeper = keeperTargetY - keeperY;

            double distanceKeeper = Math.Sqrt(deltaXkeeper * deltaXkeeper + deltaYkeeper * deltaYkeeper);

            dirXKeeper = deltaXkeeper / distanceKeeper;
            dirYKeeper = deltaYkeeper / distanceKeeper;
            timer1.Start();
        }

    }
}
