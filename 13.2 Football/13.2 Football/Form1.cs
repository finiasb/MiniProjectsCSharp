using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13._2_Football
{
    public partial class Form1 : Form
    {
        string directie = "JOS";
        int x, y;
        int scorStanga = 0;
        int scorDreapta = 0;

        public Form1()
        {
            InitializeComponent();
            x = pictureBox1.Location.X;
            y = pictureBox1.Location.Y;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W) 
            {
                directie = "SUS";
            }
            else if(e.KeyCode == Keys.S)
            {
                directie = "JOS";
            }
            else if (e.KeyCode == Keys.D)
            {
                directie = "DREAPTA";
            }
            else if(e.KeyCode == Keys.A)
            {
                directie = "STANGA";
            }
            timer1.Start();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (directie == "SUS") y -= 7;
            else if(directie == "JOS") y += 7;
            else if (directie == "DREAPTA") x += 7;
            else if (directie == "STANGA") x -= 7;

            pictureBox1.Location = new Point(x, y);

            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                scorStanga++;
                label1.Text = "Scor: " + scorStanga.ToString();
            }
            else if (pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                scorDreapta++;
                label2.Text = "Scor: " + scorDreapta.ToString();
            }
        }
    }
}
