using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17._1___Fibonacci_Game
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int[,] matrice = new int[10, 10];
        List<int> list = new List<int> { 1, 2, 3, 5, 8, 13 };
        int scor = 0;
        List<Point> points = new List<Point>();
        int circleRow = 0;
        int circleCol = 0;
        int cellSize = 50;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            points.Add(new Point(0, 0));

            GenereazaMatrice();
        }

        void GenereazaMatrice()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    matrice[i, j] = rnd.Next(1, 16);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen penGrid = new Pen(Color.Black, 1);
            Brush brushFibo = new SolidBrush(Color.LightCyan);
            Brush brushNormal = new SolidBrush(Color.LightGreen);
            Brush brushNormal2 = new SolidBrush(Color.Black);

            Brush blueBall = new SolidBrush(Color.Blue);

           

            for (int i = 0; i < 10; i++) 
            {
                for (int j = 0; j < 10; j++) 
                {
                    
                    Rectangle rect = new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize);

                    if (list.Contains(matrice[i, j]))
                        g.FillRectangle(brushFibo, rect);
                    else
                        g.FillRectangle(brushNormal, rect);

                    g.DrawRectangle(penGrid, rect);

                    string txt = matrice[i, j].ToString();
                    g.DrawString(txt, this.Font, Brushes.Black, i * cellSize + 15, j * cellSize + 15);
                }
            }
            foreach (Point p in points)
            {
                Rectangle rec = new Rectangle(p.X, p.Y, cellSize, cellSize);
                g.FillRectangle(brushNormal2, rec);
            }
            g.FillEllipse(blueBall, circleCol * cellSize + 5, circleRow * cellSize + 5, cellSize - 10, cellSize - 10);
        }
        int cntFibo, cntNormal; 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && circleRow < 9) circleRow++;
            else if (e.KeyCode == Keys.W && circleRow > 0) circleRow--;
            else if (e.KeyCode == Keys.D && circleCol < 9) circleCol++;
            else if (e.KeyCode == Keys.A && circleCol > 0) circleCol--;

            Point p = new Point(circleCol * cellSize, circleRow * cellSize);

            if (!points.Contains(p))
            {
                points.Add(p);     
                VerificaCastig();
            }
            if (list.Contains(matrice[circleCol, circleRow]))
                cntFibo++;
            else
                cntNormal++;
            panel1.Invalidate();

            if (circleCol == 9 && circleRow == 9)
            {
                scor = 0;
                GenereazaMatrice();
                points.Clear();
                points.Add(new Point(0, 0));
                circleRow = 0;
                circleCol = 0;
                panel1.Invalidate();
                label1.Text = scor.ToString();
                chart1.Visible = true;
                chart1.Series[0].Points.AddY(cntFibo);
                chart1.Series[1].Points.AddY(cntNormal);
                chart1.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                MessageBox.Show($"Jocul s-a inchiat. Scor: {scor}");
                chart1.Visible = false;
                cntFibo = 0;
                cntNormal = 0;
            }
        }
        private void VerificaCastig()
        {
            int numarCurent = matrice[circleCol, circleRow];
            if (list.Contains(numarCurent))
            {
                scor += numarCurent;
                label1.Text = scor.ToString();   
            }
            else
            {
                scor -= numarCurent;
                label1.Text = scor.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scor = 0;
            label1.Text = scor.ToString();

            GenereazaMatrice();
            points.Clear();
            points.Add(new Point(0, 0));
            circleRow = 0;
            circleCol = 0;
            chart1.Visible = false;
            cntFibo = 0;
            cntNormal = 0;
            panel1.Invalidate();
        }
    }
}
