using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _14._2_T_rex
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int jumpSpeed = 0;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        List<PictureBox> obstacles = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        private void CreateObstacle()
        {
            PictureBox obstacle = new PictureBox();
            int x = rand.Next(1, 3);
            if(x == 1)
                obstacle.Image = Properties.Resources.obstacle_1;
            else
                obstacle.Image = Properties.Resources.obstacle_2;
            obstacle.Size = new Size(40, 40);
            obstacle.SizeMode = PictureBoxSizeMode.StretchImage;
            obstacle.Left = 800; 
            obstacle.Top = 370;
            obstacle.Tag = "obstacle";

            this.Controls.Add(obstacle);
            obstacles.Add(obstacle);
        }

        private void GameOver()
        {
            timer1.Stop();
            pictureBox1.Image = Properties.Resources.dead;
            MessageBox.Show("Score: " + score);
            ResetGame();
        }

        private void ResetGame()
        {
            obstacles.Clear();

            score = 0;
            jumpSpeed = 0;
            label1.Text = "Score: 0";
            pictureBox1.Image = Properties.Resources.running;
            pictureBox1.Top = 361;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top += jumpSpeed;

            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (pictureBox1.Top >= 361) 
            {
                pictureBox1.Top = 361;
                jumpSpeed = 0;
            }
            else
            {
                jumpSpeed += 2; 
            }

            for (int i = obstacles.Count - 1; i >= 0; i--)
            {
                obstacles[i].Left -= obstacleSpeed;

                if (obstacles[i].Left < -50)
                {
                    this.Controls.Remove(obstacles[i]);
                    obstacles.RemoveAt(i);
                    score++;
                    label1.Text = "Score: " + score;
                }

                if (obstacles.Count > 0 && pictureBox1.Bounds.IntersectsWith(obstacles[i].Bounds))
                {
                    GameOver();
                }
            }

            if (rand.Next(1, 40) == 5 && obstacles.Count < 2)
            {
                CreateObstacle();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && pictureBox1.Top >= 360)
            {
                jumpSpeed = -20;
            }
        }
    }
}