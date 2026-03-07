using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Judeteana2011
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox2.TextLength > 0)
            {
                richTextBox1.SelectionColor = Color.Red;      
                richTextBox1.AppendText("Maria >> " + richTextBox2.Text + "\n");
                richTextBox2.Clear();
            }
            else
            {
                MessageBox.Show("nu ai introdus nimic");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox2.TextLength > 0)
            {
                richTextBox1.SelectionColor = Color.Blue;      
                richTextBox1.AppendText("Ionel >> " + richTextBox2.Text + "\n");
                richTextBox2.Clear();
            }
            else
            {
                MessageBox.Show("nu ai introdus nimic");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "info.txt";
            TextWriter txt = new StreamWriter(path);
            txt.Write(richTextBox1.Text);
            txt.Close();
            richTextBox1.Clear();
            MessageBox.Show("Mesaj salvat cu succes");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "info.txt";
            TextReader reader = new StreamReader(path);
            richTextBox1.Text = reader.ReadToEnd();
            reader.Close();
            MessageBox.Show("Mesajele au fost incarcate cu succes");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
