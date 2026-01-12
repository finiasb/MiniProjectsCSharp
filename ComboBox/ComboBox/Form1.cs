using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Nu ai pus nici o valoare in textBox.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int indexSters = comboBox1.SelectedIndex;
                comboBox1.Items.RemoveAt(indexSters);

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    label1.Text = "L-ai ales pe: " + comboBox1.SelectedItem.ToString();
                }
                else
                {
                    comboBox1.Text = string.Empty;
                    label1.Text = "ComboBox-ul este gol.";
                }
            }
            else
            {
                MessageBox.Show("ComboBox-ul este gol. Adaugă sau selectează ceva mai întâi.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            label1.Text = "L-ai ales pe: " + comboBox1.SelectedItem.ToString();
        }
    }
}
