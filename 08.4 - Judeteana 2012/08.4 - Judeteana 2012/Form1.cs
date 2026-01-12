using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08._4___Judeteana_2012
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "candidat";
            textBox2.Text = "cia2012";
        }

        private void lansareTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "candidat")
            {
                MessageBox.Show("Nume utilizator sau parolă gresită!! Vă rugăm reluati!");
                return;
            }
            if(textBox2.Text != "cia2012")
            {
                MessageBox.Show("Nume utilizator sau parolă gresită!! Vă rugăm reluati!");
                return;
            }
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void inchidereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
