using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12._2_Cerere
{
    public partial class Form1 : Form
    {
        Bitmap bmpSemnatura = new Bitmap(236, 138);
        Bitmap bmpfinal = new Bitmap(600, 1000);
        bool isDonw;
        int x, y;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g1 = Graphics.FromImage(bmpSemnatura);
            Graphics g2 = Graphics.FromImage(bmpfinal);
            Graphics g3 = panel1.CreateGraphics();
            Font fontText = new Font("Times New Roman", 20, FontStyle.Bold);
            string textTitlu = textBox1.Text;
            
            SizeF marimeText = g2.MeasureString(textTitlu, fontText);

            float xMijloc = (bmpfinal.Width / 2) - (marimeText.Width / 2);

            Brush brush = new SolidBrush(Color.Black);
            Brush brush2 = new SolidBrush(Color.White);
            Rectangle rec = new Rectangle(0, 0, 600, 1000);
            g2.FillRectangle(brush2, rec);
            g2.DrawString(textTitlu, fontText, brush, xMijloc, 30);

            string textCerere = textBox2.Text;

            SizeF marimeCerere = g2.MeasureString(textCerere, fontText);
            float xMijloc2 = (bmpfinal.Width / 2) - (marimeCerere.Width / 2);


            g2.DrawString(textCerere, fontText, brush, xMijloc2, 200);


            string data = dateTimePicker1.Value.ToShortDateString();

            g2.DrawString(data, fontText, brush, 30, 600);
            g2.DrawImage(bmpSemnatura, bmpfinal.Width - bmpSemnatura.Width - 30, 600);



            saveFileDialog1.FileName = "Cerere";
            saveFileDialog1.DefaultExt = "png";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                bmpfinal.Save(saveFileDialog1.FileName);
                
            }
            using (Graphics g = Graphics.FromImage(bmpSemnatura))
            {
                g.Clear(Color.White);
            }
            using (Graphics g = Graphics.FromImage(bmpfinal))
            {
                g.Clear(Color.White);
            }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            DateTime dt = DateTime.Now;
            dateTimePicker1.Value = dt;
            panel1.Invalidate();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDonw = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDonw = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g2 = Graphics.FromImage(bmpSemnatura);
            Graphics g = panel1.CreateGraphics();
            if (isDonw)
            {
                Pen pen = new Pen(Color.Black, 2);
                g.DrawLine(pen, e.X, e.Y, x, y);
                g2.DrawLine(pen, e.X, e.Y, x, y);
            }
            x = e.X; y = e.Y;
        }
    }
}
