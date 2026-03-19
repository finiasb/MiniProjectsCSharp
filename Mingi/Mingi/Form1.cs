using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Mingi
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        List<Color> colors = new List<Color>();
        List<Rectangle> rects = new List<Rectangle>();
        List<float> velocities = new List<float>();
        float gravity = 0.5f;
        float friction = 0.7f;
        public Form1()
        {
            InitializeComponent();
            RndColor();
            int x = 30;
            int y = 50;
            for (int i = 0; i < 10; i++)
            {
                int rndSize = r.Next(30, 60);
                Rectangle rectangle = new Rectangle(x, y, rndSize, rndSize);
                rects.Add(rectangle);
                x += rndSize + 20;
                velocities.Add(0f);
            }
        }
        private void gamePanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int i = 0;
            foreach (Rectangle r in rects)
            {
                Brush b = new SolidBrush(colors[i]);
                g.FillEllipse(b, r);
                i++;
            }
        }

        void RndColor()
        {
            colors.Clear();
            for (int i = 1; i <= 10; i++)
            {
                int rndN = r.Next(0, 6);

                if (rndN == 0)
                    colors.Add(Color.Black);
                else if (rndN == 1)
                    colors.Add(Color.Blue);
                else if (rndN == 2)
                    colors.Add(Color.Magenta);
                else if (rndN == 3)
                    colors.Add(Color.LightGreen);
                else if (rndN == 4)
                    colors.Add(Color.Pink);
                else if (rndN == 5)
                    colors.Add(Color.Orange);
                else if (rndN == 6)
                    colors.Add(Color.MintCream);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < rects.Count; i++)
            {
                Rectangle r = rects[i];
                float v = velocities[i];

                v += gravity;
                float nextY = r.Y + v;

                if (nextY + r.Height >= 300)
                {
                    nextY = 300 - r.Height;
                    v = -v * friction;

                    if (Math.Abs(v) < 1.0f) v = 0;
                }

                r.Y = (int)nextY;
                rects[i] = r;
                velocities[i] = v;
            }
            gamePanel1.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}

