using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._2_Charts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            General gen = new General();
            gen.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Materii mat = new Materii();
            mat.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            System.Environment.Exit(0);

        }
    }
}
