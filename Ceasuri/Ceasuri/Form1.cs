using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ceasuri
{
    public partial class Form1 : Form
    {

        int centreX = 200 - 20;
        int centreY = 200 - 20;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            label1.Location = new Point(centreX - 130, centreY - 20);
            label2.Location = new Point(centreX - 15 , centreY - 130);
            label3.Location = new Point(centreX + 115, centreY - 20);
            label4.Location = new Point(centreX - 10, centreY + 115);

        }
        double unghiSecunde = 0;
        double unghiMinute = 0;
        double unghiOre = 0;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Black, 1);
            Pen pen1 = new Pen(Color.Black, 3);
            Pen pen2 = new Pen(Color.Black, 5);

            int raza = 100;
            double radSecunde = (unghiSecunde * Math.PI) / 180;
            double radMinute= (unghiMinute * Math.PI) / 180;
            double radOre = (unghiOre * Math.PI) / 180;

            double xSecunde = centreX + raza * Math.Cos(radSecunde - Math.PI / 2);
            double ySecunde = centreY + raza * Math.Sin(radSecunde - Math.PI / 2);

            double xMinute = centreX + (raza - 15) * Math.Cos(radMinute - Math.PI / 2);
            double yMinute = centreY + (raza - 15) * Math.Sin(radMinute - Math.PI / 2);

            double xOre = centreX + (raza - 30) * Math.Cos(radOre - Math.PI / 2);
            double yOre = centreY + (raza - 30) * Math.Sin(radOre - Math.PI / 2);


            g.DrawLine(pen, centreX, centreY, (int)xSecunde, (int)ySecunde);
            g.DrawLine(pen1, centreX, centreY, (int)xMinute , (int)yMinute);
            g.DrawLine(pen2, centreX, centreY, (int)xOre, (int)yOre);
            g.DrawEllipse(pen, centreX - 110, centreY - 110, 220, 220);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            unghiSecunde = now.Second * 6;        
            unghiMinute = now.Minute * 6 + now.Second; 
            unghiOre = (now.Hour % 12) * 30 + now.Minute; 
            this.Invalidate();
        }
    }
}
