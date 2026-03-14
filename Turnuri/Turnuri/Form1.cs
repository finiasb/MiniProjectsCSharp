using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turnuri
{
    public partial class Form1 : Form
    {
        string path = System.AppDomain.CurrentDomain.BaseDirectory + "turnuri.txt";
        List<int> turnH = new List<int>();
        List<Color> turnC = new List<Color>();
        List<int> turnH2 = new List<int>();
        List<Color> turnC2 = new List<Color>();
        public Form1()
        {
            InitializeComponent();
            incarcare();
        }
        void incarcare()
        {
            StreamReader rdr = new StreamReader(path);
            string line;
            rdr.ReadLine();
            while((line = rdr.ReadLine()) != null)
            {
                string[] c = line.Split(' ');
                Color color = Color.Magenta;
                if (c[1] == "Red")
                    color = Color.Red;
                else if (c[1] == "Green")
                    color = Color.Green;
                else if (c[1] == "Blue")
                    color = Color.Blue;
                else if (c[1] == "Yellow")
                    color = Color.Yellow;
                else if (c[1] == "Black")
                    color = Color.Black;
                else if (c[1] == "Pink")
                    color = Color.Pink;


                turnC.Add(color);
                turnH.Add(int.Parse(c[0]));
                turnC2.Add(color);
                turnH2.Add(int.Parse(c[0]));
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int x = 0;

            for(int i = 0; i < turnC.Count; i++)
            {
                Color c = turnC2[i];
                int h = turnH2[i];
                Brush brush = new SolidBrush(c);
                Pen pen = new Pen(brush);
                int y = 120 - h * 20;
                Rectangle rec = new Rectangle(x, y, h * 20, h * 20);
                graphics.DrawRectangle(pen, rec);
                graphics.FillRectangle(brush, rec);

                x += h * 20 + 3;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < turnC.Count; i++)
            {
                for (int j = 0; j < turnC.Count; j++)
                {
                    if (turnH[i] > turnH[j])
                    {
                        int aux = turnH[i];
                        turnH[i] = turnH[j];
                        turnH[j] = aux;

                        Color c = turnC[i];
                        turnC[i] = turnC[j];
                        turnC[j] = c;
                    }
                }
            }
            Graphics g = e.Graphics;
            int y = 500;
            int x = 75;
            Color cLast = Color.Wheat;
            int hLast = 100;
            for (int i = 0; i < turnC.Count; i++)
            {
                Color c = turnC[i];
                int h = turnH[i];
                if(i == 0)
                {
                    Brush brush = new SolidBrush(c);
                    Pen pen = new Pen(brush);
                    y -= h * 20;
                    Rectangle rec = new Rectangle(x, y, h * 20, h * 20);
                    g.DrawRectangle(pen, rec);
                    g.FillRectangle(brush, rec);
                    cLast = c;
                    hLast = h;
                }
                else if(c != cLast &&  h < hLast)
                {
                    Brush brush = new SolidBrush(c);
                    Pen pen = new Pen(brush);
                    y -= h * 20;
                    x = x + (hLast * 20 - h * 20)  / 2;
                    Rectangle rec = new Rectangle(x, y, h * 20, h * 20);
                    g.DrawRectangle(pen, rec);
                    g.FillRectangle(brush, rec);
                    cLast = c;
                    hLast = h;
                }
            }
        }
    }
}
