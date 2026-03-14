using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pistoane
{
    public partial class Form1 : Form
    {
        double unghi = 0;
        int raza = 100;
        int centruX = 600 / 2;
        int centruY = 500 / 2 - 125;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Blue);

            double radieni = (unghi * Math.PI) / 180;
            double x = centruX + (raza * Math.Cos(radieni));
            double y = centruY + (raza * Math.Sin(radieni));

            Rectangle rec = new Rectangle(centruX - raza, centruY + raza + 50, 200, 300);
            Rectangle rec1 = new Rectangle((int)centruX - raza, (int)y + 250, 200, (int)(325 - y));
            g.DrawEllipse(pen, centruX - raza, centruY - raza, raza * 2, raza * 2);
            g.DrawLine(pen, centruX, centruY, (int)x, (int)y);
            g.DrawLine(pen, (int)x, (int)y, centruX , (int)y + 250);
            g.DrawRectangle(pen, rec);
            g.FillRectangle(brush, rec1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            unghi += 5;
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == false)
                timer1.Start();
            else
                timer1.Stop();
        }
    }
}
