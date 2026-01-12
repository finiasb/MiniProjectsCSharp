using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07._3_First_Paint
{
    
    public partial class Form1 : Form
    {
        private Color culoare = Color.Empty;
        Point puncteInitiale = new Point();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                culoare = colorDialog1.Color;  
            } 
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            puncteInitiale = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            if (radioButton1.Checked)
            {
                int x0 = puncteInitiale.X;
                int y0 = puncteInitiale.Y;
                int x1 = e.X;
                int y1 = e.Y;
                Graphics g = panel1.CreateGraphics();
                Pen pen = new Pen(culoare, trackBar1.Value);
                int x = Math.Min(x0, x1);
                int y = Math.Min(y0, y1);
                int width = Math.Abs(x1 - x0);
                int height = Math.Abs(y1 - y0);
                g.DrawEllipse(pen, x, y, width, height);
            }
            else if (radioButton2.Checked)
            {
                int x0 = puncteInitiale.X;
                int y0 = puncteInitiale.Y;
                int x1 = e.X;
                int y1 = e.Y;
                Graphics g = panel1.CreateGraphics();
                Pen pen = new Pen(culoare, trackBar1.Value);
                int x = Math.Min(x0, x1);
                int y = Math.Min(y0, y1);
                int width = Math.Abs(x1 - x0);
                int height = Math.Abs(y1 - y0);
                g.DrawRectangle(pen, x, y, width, height);
            }
            else if (radioButton3.Checked)
            {
                Color culoareaPixelului = GetPixelColorFromPanel(e.X, e.Y);
                if (culoareaPixelului.ToArgb() != culoare.ToArgb())
                {
                    FloodFillIterative(e.X, e.Y, culoareaPixelului, culoare);
                }
            }
        }
        private void FloodFillIterative(int startX, int startY, Color targetColor, Color fillColor)
        {
            if (targetColor.ToArgb() == fillColor.ToArgb()) 
                return;

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(new Point(startX, startY));

            while (pixels.Count > 0)
            {
                Point pt = pixels.Pop();
                int x = pt.X;
                int y = pt.Y;

                if (x < 0 || y < 0 || x >= panel1.Width || y >= panel1.Height)
                    continue;

                Color currentColor = GetPixelColorFromPanel(x, y);
                if (currentColor.ToArgb() != targetColor.ToArgb())
                    continue;

                using (Graphics g = panel1.CreateGraphics())
                {
                    g.FillRectangle(new SolidBrush(fillColor), x, y, 1, 1);
                }

                pixels.Push(new Point(x + 1, y));
                pixels.Push(new Point(x - 1, y));
                pixels.Push(new Point(x, y + 1));
                pixels.Push(new Point(x, y - 1));
            }
        }



        private Color GetPixelColorFromPanel(int x, int y)
        {
            Bitmap bmp = new Bitmap(1, 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                Point screenPoint = panel1.PointToScreen(new Point(x, y));
                g.CopyFromScreen(screenPoint, new Point(0, 0), new Size(1, 1));
            }

            return bmp.GetPixel(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
