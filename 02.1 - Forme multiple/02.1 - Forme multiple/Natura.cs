using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormeMultiple
{
    public partial class Natura : Form
    {
        string nume;
        public Natura(string nume)
        {
            InitializeComponent();
            this.nume = nume;
            label1.Text = "Salut, " + nume;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
