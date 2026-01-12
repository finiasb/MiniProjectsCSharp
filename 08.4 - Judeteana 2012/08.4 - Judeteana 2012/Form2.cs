using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _08._4___Judeteana_2012
{
    public partial class Form2 : Form
    {
        private string intrebare1 = "Care dintre tipurile de date de mai jos nu apartin limbajului C++?";
        private string intrebare2 = "In urma carei operatii de atribuire, data b va avea valoarea ultimei cifre a numarului intreg a?";
        private bool intrebare1Raspuns = false;
        private bool intrebare2Raspuns = false;
        public Form2()
        {
            InitializeComponent();
            textBox1.ForeColor = System.Drawing.Color.Blue;
            IntrebareNR1();
        }

        private void IntrebareNR1()
        {
            textBox1.Text = intrebare1;
            radioButton1.Text = "int";
            radioButton2.Text = "decimal";
            radioButton3.Text = "string";
            radioButton4.Text = "float";
            button4.Visible = true;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        private void IntrebareNR2()
        {
            textBox1.Text = intrebare2;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            radioButton1.Text = "float";
            radioButton2.Text = "double";
            radioButton3.Text = "int";
            radioButton4.Text = "unsigned";
            button4.Visible = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private int intrebareCurenta = 1;

        private void button3_Click(object sender, EventArgs e) // Next
        {
            if (intrebareCurenta == 1)
            {
                intrebareCurenta = 2;
                IntrebareNR2();
            }
            else
            {
                MessageBox.Show("Nu mai sunt alte intrebari");
            }
        }

        private void button2_Click(object sender, EventArgs e) // Previous
        {
            if (intrebareCurenta == 2)
            {
                intrebareCurenta = 1;
                IntrebareNR1();
            }
            else
            {
                MessageBox.Show("Nu sunt intrebari precedente");
            }
        }

        private int punctaj = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == intrebare1 && intrebare1Raspuns == false)
            {
                if(radioButton2.Checked)
                {
                    punctaj += 10;
                }
                intrebare1Raspuns = true;
            }
            else if(textBox1.Text == intrebare1 && intrebare1Raspuns == true)
            {
                MessageBox.Show("ati raspuns deja la aceasta intrebare");
            }

            if (textBox1.Text == intrebare2 && intrebare2Raspuns == false)
            {
                if (radioButton3.Checked)
                {
                    punctaj += 10;
                }
                intrebare2Raspuns = true;
            }
            else if (textBox1.Text == intrebare2 && intrebare2Raspuns == true)
            {
                MessageBox.Show("ati raspuns deja la aceasta intrebare");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "Punctaj: " + punctaj.ToString();
            button2.Visible = false;
            button3.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            button4.Enabled = false;
        }
    }
}
