using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._2___Checker_Board
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int scor;
        Bitmap bmp;
        int cells = 9;
        int cellSize = 50;
        int size = 450;
        int circleRow = 0;      
        int circleCol = 0;
        int x, y;
        public Form1()
        {
            InitializeComponent();
            x = rnd.Next(1, 10);
            y = rnd.Next(1, 10);
            label2.Text = "Linia:      " + x;
            label3.Text = "Coloana: " + y;

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            
            Pen pen = new Pen(Color.Black, 6);
            Brush red = new SolidBrush(Color.Red);
            Brush blue = new SolidBrush(Color.Blue);

            for (int row = 0; row < cells; row++)
            {
                for (int col = 0; col < cells; col++)
                {
                    if((col + row) % 2 == 1)
                        g.FillRectangle(red, col * cellSize, row * cellSize, cellSize, cellSize);
                }
            }
            for (int i = 0; i <= cells; i++)
            {
                int pos = i * cellSize;
                g.DrawLine(pen, pos, 0, pos, size);
                g.DrawLine(pen, 0, pos, size, pos);
            }
            g.FillEllipse(blue, circleCol * cellSize, circleRow * cellSize , cellSize - 2 , cellSize - 2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                if (circleRow < cells - 1)  
                {
                    circleRow++;             
                    pictureBox1.Invalidate();
                    felicitari();
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                if (circleCol > 0)
                {
                    circleCol--;
                    pictureBox1.Invalidate();
                    felicitari();
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                if (circleCol < cells - 1)
                {
                    circleCol++;
                    pictureBox1.Invalidate();
                    felicitari();
                }
            }
            else if (e.KeyCode == Keys.W)
            {
                if (circleRow > 0)
                {
                    circleRow--;
                    pictureBox1.Invalidate();
                    felicitari();
                }
            }
        }

        private void felicitari()
        {
            if (circleCol + 1 == x && circleRow + 1 == y)
            {
                MessageBox.Show("Felicitari");
                scor++;
                label4.Text = "Scor: " + scor;
                x = rnd.Next(1, 10);
                y = rnd.Next(1, 10);
                label2.Text = "Linia:      " + x;
                label3.Text = "Coloana: " + y;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.FromArgb(18, 22, 29);

        }

        private void drawBallDown()
        {
            
        }
    }
}
