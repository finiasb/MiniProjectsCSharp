using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08._1___Putina_miscare
{
    public partial class Form1 : Form
    {
        private int x1 = 149;
        private int x2 = 149;
        private int x3 = 149;

        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.Timer Timer3;
        public Form1()
        {
            InitializeComponent();
        }

        private void TimerMiscare1()
        {
            Timer1 = new System.Windows.Forms.Timer();
            Timer1.Interval = 150;
            Timer1.Tick += Timer_Tick1;
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Red, 1);
            Brush brush = new SolidBrush(Color.Red);
            g.Clear(Color.RoyalBlue);
            g.DrawEllipse(pen, x1, 70, 30, 30);
            g.FillEllipse(brush, x1, 70, 30, 30);
            x1 += 5;
            if (x1 >= 590)
                x1 = 149;
        }
        private void TimerMiscare2()
        {
            Timer2 = new System.Windows.Forms.Timer();
            Timer2.Interval = 50;
            Timer2.Tick += Timer_Tick2;
        }

        private void Timer_Tick2(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Cyan, 1);
            Brush brush = new SolidBrush(Color.Cyan);
            g.Clear(Color.RoyalBlue);
            g.DrawEllipse(pen, x2, 215, 60, 60);
            g.DrawEllipse(pen, x2 + 7, 180, 50, 50);
            g.DrawEllipse(pen, x2 + 14, 160, 35, 35);
            g.FillEllipse(brush, x2, 215, 60, 60);
            g.FillEllipse(brush, x2 + 7, 180, 50, 50);
            g.FillEllipse(brush, x2 + 14, 160, 35, 35);

            if (x2 >= 590)
                x2 = 149;
            x2 += 5;
        }
        private void TimerMiscare3()
        {
            Timer3 = new System.Windows.Forms.Timer();
            Timer3.Interval = 50;
            Timer3.Tick += Timer_Tick3;
        }

        private void Timer_Tick3(object sender, EventArgs e)
        {
            //150, 315
            Graphics g = this.CreateGraphics();
            g.Clear(Color.RoyalBlue);
            pictureBox1.Location = new Point(x3, 315);
            x3 += 5;
            if (x3 >= 590)
                x3 = 149;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimerMiscare1();
            Timer1.Start();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Timer1.Stop();
            button1.Enabled = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"{e.X}, {e.Y}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimerMiscare2();
            Timer2.Start();
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = true; 
            Timer2.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Timer3.Stop();
            button5.Enabled = true;
            pictureBox1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            TimerMiscare3();
            Timer3.Start();
            button5.Enabled = false;
        }
    }
}
//140 215