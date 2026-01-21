using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09._1_RGB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            trackBar1.Value = 255;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(trackBar1.Value, (int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            pictureBox1.BackColor = c;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(trackBar1.Value, (int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            pictureBox1.BackColor = c;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(trackBar1.Value, (int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            pictureBox1.BackColor = c;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(trackBar1.Value, (int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            pictureBox1.BackColor = c;
        }
    }
}
