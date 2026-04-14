using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fibonaci
{
    public partial class Form1 : Form
    {
        List<int> sirFibo = new List<int>();    
        public Form1()
        {
            InitializeComponent();
            sirFibonaci();

            string line = "";
            foreach (int i in sirFibo)
                line += i + " ";

        }

        private void sirFibonaci()
        {
            sirFibo.Clear();

            sirFibo.Add(1);
            sirFibo.Add(1);

            for(int i = 2; i <= numericUpDown1.Value; i++)
            {
                sirFibo.Add(sirFibo[i - 2] + sirFibo[i - 1]);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            Pen arc = new Pen(Color.Red, 2);

            int x = 390, y = 240;
            for(int i = 0; i  < numericUpDown1.Value; i++)
            {
                if (i == 1)
                {
                    y += 10;
                }
                if (i == 2)
                {
                    y -= 10;
                    x += 10;
                    Rectangle rectangle = new Rectangle(390, 250, 10 * 2, 10 * 2);
                    g.DrawArc(arc, rectangle.X, rectangle.Y - 10, 10 * 2, 10 * 2, 90, 90);
                }
                if (i == 3)
                {
                    y -= 30;
                    x -= 10;
                    Rectangle rectangle = new Rectangle(400, 240, 20 * 2, 20 * 2);
                    g.DrawArc(arc, rectangle.X - 20, rectangle.Y - 20, 20 * 2, 20 * 2, 360, 90);
                }
                if (i == 4)
                {
                    x -= 50;
                    Rectangle rectangle = new Rectangle(390, 210, 30 * 2, 30 * 2);
                    g.DrawArc(arc, rectangle.X - 30, rectangle.Y, 30 * 2, 30 * 2, 270, 90);
                }
                if (i == 5)
                {
                    y += 50;
                    Rectangle rectangle = new Rectangle(340, 260, 80 * 2, 80 * 2);

                    g.DrawArc(arc, rectangle.X, rectangle.Y - 80, 80 * 2, 80 * 2, 90, 90);

                }
                if (i == 6)
                {
                    y -= 50;
                    x += 80;
                    Rectangle rectangle = new Rectangle(340 + 80, 210, 130 * 2, 130 * 2);
                    g.DrawArc(arc, rectangle.X - 130, rectangle.Y - 130, 130 * 2, 130 * 2, 360, 90);
                }
                if (i == 7)
                {
                    y -= 210;
                    x -= 80;
                    Rectangle rec2122 = new Rectangle(340, 0, 210 * 2, 210 * 2);
                    g.DrawArc(arc, rec2122.X / 2 - 40, rec2122.Y, 210 * 2, 210 * 2, 270, 90);
                }
                if (i == 8)
                {
                    y = 0;
                    x = 0;
                }

                int fibHW = (int)sirFibo[i] * 10;
                Rectangle rec1 = new Rectangle(x, y, fibHW, fibHW);
                g.DrawRectangle(pen, rec1);
                Rectangle rec2 = new Rectangle(x, y, fibHW * 2, fibHW * 2);

                if (i == 0)
                    continue;
                
                if ((i - 1) % 4 == 3)
                    g.DrawArc(arc, rec2, 180, 90);
            }


        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.X + " " + e.Y);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            sirFibonaci();
            panel1.Invalidate();
        }
    }
}
