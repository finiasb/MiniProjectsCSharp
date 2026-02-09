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

namespace _12._3_Snake
{
    public partial class Form1 : Form
    {
        List<Cerc> cercs = new List<Cerc>();    
        Random rnd = new Random();
        bool existaMancare = false;
        Cerc cercnou;
        CercMancare cercMancare;
        public Form1()
        {
            InitializeComponent();


            Cerc cercnou = new Cerc(10 * 20, 10 * 20);
            cercs.Add(cercnou);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            cercs.Clear();
            Cerc cercnou = new Cerc(10 * 20, 10 * 20);
            cercs.Add(cercnou);

            cercMancare = new CercMancare(-20, -20);
            cercMancare.ReseteazaPozitie(rnd.Next(5, 15) * 20, rnd.Next(5, 15) * 20);
            existaMancare = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            int x = 0;  
            /*for(int  i = 0; i <= 400; i+= 20)
            {
                g.DrawLine(pen, x, 0, x, 400);
                x += 20;
            }
            x = 0;
            for (int i = 0; i <= 400; i += 20)
            {
                g.DrawLine(pen, 0, x, 400, x);
                x += 20;
            }*/

            cercs[0].deseneaza(e.Graphics, Color.RoyalBlue);
            for(int i = 1; i < cercs.Count; i++)
            {
                if (cercs[i] != null)
                   cercs[i].deseneaza(e.Graphics, Color.CornflowerBlue);
            }
            

            if (cercMancare != null)
            {
                cercMancare.deseneazaMancare(e.Graphics);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        int scor;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int vechiulX = cercs[cercs.Count - 1].x;
            int vechiulY = cercs[cercs.Count - 1].y;

            for (int i = cercs.Count - 1; i > 0; i--)
            {
                cercs[i].x = cercs[i - 1].x;
                cercs[i].y = cercs[i - 1].y;
            }

            if (directie == "JOS") cercs[0].y += 20;
            else if (directie == "SUS") cercs[0].y -= 20;
            else if (directie == "STINGA") cercs[0].x -= 20;
            else if (directie == "DREAPTA") cercs[0].x += 20;

            if (cercs[0].x == cercMancare.x && cercs[0].y == cercMancare.y)
            {
                existaMancare = false;
                scor++;
                label1.Text = "Scor " + scor; 
                cercs.Add(new Cerc(vechiulX, vechiulY));
            }

            if (existaMancare == false)
            {
                cercMancare.ReseteazaPozitie(rnd.Next(1, 19) * 20, rnd.Next(1, 19) * 20);
                existaMancare = true;
            }

            if (cercs[0].x < 0 || cercs[0].x >= 400 || cercs[0].y < 0 || cercs[0].y >= 400)
            {
                timer1.Stop();
                MessageBox.Show("Game Over! Scor: " + scor);
                return;
            }
            for (int i = 1; i < cercs.Count; i++)
            {
                if (cercs[0].x == cercs[i].x && cercs[0].y == cercs[i].y)
                {
                    timer1.Stop();
                    MessageBox.Show("Ai murit! Scor: " + scor);
                    return; 
                }
            }
            panel1.Invalidate();
        }

        string directie = "SUS";
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && directie != "SUS") 
                directie = "JOS";
            else if (e.KeyCode == Keys.W && directie != "JOS")
                directie = "SUS";
            else if (e.KeyCode == Keys.A && directie != "DREAPTA")
                directie = "STINGA";
            else if (e.KeyCode == Keys.D && directie != "STINGA") 
                directie = "DREAPTA";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
            saveFileDialog1.FileName = "snake";
            saveFileDialog1.DefaultExt = "png";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(saveFileDialog1.FileName);
                timer1.Stop ();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
