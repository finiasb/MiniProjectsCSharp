using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonRegulat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int n = trackBar1.Value;

            Pen pen = new Pen(Color.Red, 2);
            PointF[] points = new PointF[n];

            float centerX = panel1.Width / 2;
            float centerY = panel1.Height / 2;
            float raza = 200;

            double unghi = 2 * Math.PI / n;

            for (int i = 0; i < n; i++)
            {
                float x = centerX + (float)(raza * Math.Cos(i * unghi - Math.PI / 2));
                float y = centerY + (float)(raza * Math.Sin(i * unghi - Math.PI / 2));

                points[i] = new PointF(x, y);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    g.DrawLine(pen, points[i], points[j]);
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}
