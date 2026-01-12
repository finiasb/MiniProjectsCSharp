using System;
using System.Drawing;
using System.Windows.Forms;

namespace _07._1_Xmas_mood
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int ok = 0;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 1; i <= 10; i++) 
            {
                fulgi();
            }
        }

        private void curatare(Graphics g)
        {
            g.Clear(BackColor);
        }

        private void fulgi()
        {
            Graphics g = panel1.CreateGraphics();
            int x = random.Next(1, 816);
            int y = random.Next(1, 489);
           
            int p = random.Next(10, 20);
            
            Point p1 = new Point(x - p, y);
            Point p2 = new Point(x + p, y);

            Point p3 = new Point(x, y - p);
            Point p4 = new Point(x, y + p);

            Point p5 = new Point(x - p, y - p);
            Point p6 = new Point(x + p, y + p);

            Point p7 = new Point(x + p, y - p);
            Point p8 = new Point(x - p, y + p);
            Pen pen = new Pen(Color.Cyan, 2);
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p3, p4);
            g.DrawLine(pen, p5, p6);
            g.DrawLine(pen, p7, p8);
        }

        private void omDeZapada(Point p1)
        {
            Graphics g = panel1.CreateGraphics ();
            Pen penBlack = new Pen(Color.Black, 7);
            Pen penBlue = new Pen(Color.Blue, 7);
            Pen pen = new Pen(Color.Black, 3);
            SolidBrush brushGray = new SolidBrush(Color.Gray);
            SolidBrush brushBlue = new SolidBrush(Color.LightBlue);
            int x = p1.X;
            int y = p1.Y;
            int z = 40;
            Point p2 = new Point(x + 90 - z, y + z + 50);
            Point p3 = new Point(x + 90 + z, y - z + 50);

            g.DrawEllipse(penBlue, x - 23, y + 100, 100, 80);
            g.FillEllipse(brushBlue, x - 23, y + 100, 100, 80);

            g.DrawEllipse(penBlue, x - 14, y + 60, 80, 65);
            g.FillEllipse(brushBlue, x - 14, y + 60, 80, 65);

            g.DrawRectangle(penBlack, x, y, 50, 50);
            g.FillRectangle(brushGray, x, y, 50, 50);

            g.DrawEllipse(penBlue, x - 5, y + 20, 60, 50);
            g.FillEllipse(brushBlue, x - 5, y + 20, 60, 50);

            g.DrawLine(pen, p2, p3);

        }

        private int oameni = 1;
        private void button2_Click(object sender, EventArgs e)
        {

            if(oameni == 1)
            {
                Point p1 = new Point(80, 80);
                omDeZapada(p1);
                oameni++;
            }
            else if(oameni == 2)
            {
                Point p2 = new Point(300, 30);
                omDeZapada(p2);
                oameni++;
            }
            else if(oameni == 3)
            {
                Point p3 = new Point(500, 200);
                omDeZapada(p3);
                oameni++;
            }
            else 
            {
                MessageBox.Show("Ai atins numarul maxim de oameni");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ok == 0)
            {
                Graphics g = panel1.CreateGraphics();
                Pen pen = new Pen(Color.DarkGreen, 10);
                SolidBrush brush = new SolidBrush(Color.LightGreen);
                Point p1 = new Point(180, 220);
                Point p2 = new Point(130, 300);
                Point p3 = new Point(230, 300);
                Point[] points = { p1, p2, p3 };
                g.DrawPolygon(pen, points);
                g.FillPolygon(brush, points);
                Pen penBrown = new Pen(Color.Brown, 4);
                SolidBrush brushBrown = new SolidBrush(Color.SaddleBrown);

                g.DrawRectangle(penBrown, 165, 307, 30, 70);
                g.FillRectangle(brushBrown, 165, 307, 30, 70);
                ok = 1;
            }
            else
            {
                MessageBox.Show("Ai desenat deja un brad");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.RoyalBlue);
            oameni = 1;
            ok = 0;
        }
    }
}