using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheDragon
{
    public partial class Form1 : Form
    {
        List<int> o = new List<int>() { 90 };

        public Form1()
        {
            InitializeComponent();
            GenerateDragon();
        }
        private void GenerateDragon()
        {
            for (int z = 0; z < 17; z++)
            {
                List<int> temp = new List<int>(o);
                temp.Reverse();

                List<int> neg = new List<int>();
                foreach (int x in temp)
                    neg.Add(-x);

                o.Add(90);
                o.AddRange(neg);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            float x = 800, y = 300;
            float unghi = 0;
            float l = 1f;

            foreach (int turn in o)
            {
                float rad = (float)(Math.PI * unghi / 180.0);
                float newX = x + (float)(Math.Cos(rad) * l);
                float newY = y + (float)(Math.Sin(rad) * l);

                e.Graphics.DrawLine(pen, x, y, newX, newY);

                x = newX;
                y = newY;

                unghi += turn;
            }
        }
    }
}
