using System;
using System.Drawing;
using System.Windows.Forms;

namespace _06._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            panel1.Paint += romania;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Paint -= romania;
            panel1.Paint -= ucraina;
            panel1.Paint -= rusia;

            if (comboBox1.SelectedIndex == 0)
                panel1.Paint += romania;
            else if (comboBox1.SelectedIndex == 1)
                panel1.Paint += ucraina;
            else if (comboBox1.SelectedIndex == 2)
                panel1.Paint += rusia;

            panel1.Invalidate();   
        }

        void romania(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            SolidBrush fillBlue = new SolidBrush(Color.Blue);
            SolidBrush fillYellow = new SolidBrush(Color.Yellow);
            SolidBrush fillRed = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(50, 50, 66, 100);
            Rectangle rect2 = new Rectangle(116, 50, 66, 100);
            Rectangle rect3 = new Rectangle(182, 50, 66, 100);

            e.Graphics.FillRectangle(fillBlue, rect);
            e.Graphics.FillRectangle(fillYellow, rect2);
            e.Graphics.FillRectangle(fillRed, rect3);

            e.Graphics.DrawRectangle(blackPen, rect);
            e.Graphics.DrawRectangle(blackPen, rect2);
            e.Graphics.DrawRectangle(blackPen, rect3);
        }

        void ucraina(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            SolidBrush fillBlue = new SolidBrush(Color.Blue);
            SolidBrush fillYellow = new SolidBrush(Color.Yellow);

            Rectangle rect = new Rectangle(50, 50, 200, 66);
            Rectangle rect2 = new Rectangle(50, 116, 200, 66);

            e.Graphics.FillRectangle(fillBlue, rect);
            e.Graphics.FillRectangle(fillYellow, rect2);

            e.Graphics.DrawRectangle(blackPen, rect);
            e.Graphics.DrawRectangle(blackPen, rect2);
        }

        void rusia(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            SolidBrush fillWhite = new SolidBrush(Color.White);
            SolidBrush fillBlue = new SolidBrush(Color.Blue);
            SolidBrush fillRed = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(50, 50, 200, 50);
            Rectangle rect2 = new Rectangle(50, 100, 200, 50);
            Rectangle rect3 = new Rectangle(50, 150, 200, 50);

            e.Graphics.FillRectangle(fillWhite, rect);
            e.Graphics.FillRectangle(fillBlue, rect2);
            e.Graphics.FillRectangle(fillRed, rect3);

            e.Graphics.DrawRectangle(blackPen, rect);
            e.Graphics.DrawRectangle(blackPen, rect2);
            e.Graphics.DrawRectangle(blackPen, rect3);
        }
    }
}
