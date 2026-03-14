using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CercuriSiPlusuri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            int x1 = e.X - 10;
            int y1 = e.Y;
            int x2 = e.X;
            int y2 = e.Y - 10;

            g.DrawLine(pen, x1, y1, x1 + 20, y1);
            g.DrawLine(pen, x2, y2, x2, y2 + 20);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            int x1 = e.X - 10;
            int y1 = e.Y;
            int x2 = e.X;
            int y2 = e.Y - 10;

            Rectangle rec1 = new Rectangle(e.X - 10, e.Y - 10, 20, 20);
            Rectangle rec2 = new Rectangle(e.X - 20, e.Y - 20, 40, 40);
            Rectangle rec3 = new Rectangle(e.X - 30, e.Y - 30, 60, 60);
            Rectangle rec4 = new Rectangle(e.X - 40, e.Y - 40, 80, 80);
            Rectangle rec5 = new Rectangle(e.X - 50, e.Y - 50, 100, 100);


            g.DrawLine(pen, x1, y1, x1 + 20, y1);
            g.DrawLine(pen, x2, y2, x2, y2 + 20);
            g.DrawEllipse(pen, rec1);
            g.DrawEllipse(pen, rec2);
            g.DrawEllipse(pen, rec3);
            g.DrawEllipse(pen, rec4);
            g.DrawEllipse(pen, rec5);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString();
            label2.Text = e.Y.ToString();
        }
    }
}
