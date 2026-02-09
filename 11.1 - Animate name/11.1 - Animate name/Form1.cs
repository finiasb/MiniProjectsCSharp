using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._1___Animate_name
{
    public partial class Form1 : Form
    {
        List<Cerc> cercs = new List<Cerc>();    
        Bitmap bmp = new Bitmap(700, 400);
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Cerc c in cercs)
            {
                c.Deseneaza(e.Graphics);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Cerc cercnou = new Cerc(e.X - 15, e.Y - 15);
            cercs.Add(cercnou);

            panel1.Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cercs.Clear();
            panel1.Invalidate();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g2 = Graphics.FromImage(bmp);
            g2.Clear(Color.Gainsboro);
            foreach (Cerc c in cercs)
            {
                c.Deseneaza(g2);
            }

            saveFileDialog1.FileName = "desen";
            saveFileDialog1.DefaultExt = "png";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(saveFileDialog1.FileName);
            }
            
        }
        int x = 0;
        private void animeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            graphics.Clear(Color.Gainsboro);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(x < cercs.Count)
            {
                cercs.ElementAt(x).Deseneaza(panel1.CreateGraphics());
                x++;
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
