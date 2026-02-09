using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12._1_Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp = new Bitmap(600, 400);
        int x, y;
        bool isDown = false;
        Color color;
        bool c;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            x = e.X; 
            y = e.Y;

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            c = true;   
            PictureBox pic = new PictureBox();
            pic = (sender as PictureBox);
            color = pic.BackColor;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g2 = Graphics.FromImage(bmp);
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.RoyalBlue);
            g2.Clear(Color.RoyalBlue);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "DesenulMeu";
            saveFileDialog1.DefaultExt = "png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(saveFileDialog1.FileName);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g2 = Graphics.FromImage(bmp);
            Graphics g = panel1.CreateGraphics();
            if (isDown)
            {
                if (!c)
                {
                    return;
                }
                Pen pen = new Pen(color, 2);
                g.DrawLine(pen, e.X, e.Y, x, y);
                g2.DrawLine(pen, e.X, e.Y, x, y);
            }
            x = e.X; y = e.Y;
        }
    }
}
