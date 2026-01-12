 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Timp
{
    public partial class Form1 : Form
    {
        private string _anul, _luna, _ziua;
        public Form1(string anul, string luna, string ziua)
        {
            InitializeComponent();
            _anul = anul;
            _luna = luna;
            _ziua = ziua;
            radioButton2.Checked = true;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            label2.Visible = true;
            dateTimePicker1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                TimeSpan dif = dateTimePicker2.Value - dateTimePicker1.Value;
                int zile = dif.Days + 1;
                MessageBox.Show($"Diferenta de zile: {zile}");
            }
            else if (radioButton2.Checked)
            {
                int x = Int32.Parse(_anul);
                int y = Int32.Parse(_luna);
                int z = Int32.Parse(_ziua);
                DateTime dateTime = new DateTime(x, y, z);
                TimeSpan dif = DateTime.Now - dateTime;
                int days = dif.Days;
                MessageBox.Show($"De la nastere, au trecut: {days} zile");

            }
            else if (radioButton3.Checked)
            {
                TimeSpan dif = dateTimePicker2.Value - DateTime.Now;
                int zile = dif.Days + 1;
                MessageBox.Show($"Diferenta de zile: {zile}");
            }
        }

        private void click_radbtn2(object sender, EventArgs e)
        {
            label2.Visible = false;
            dateTimePicker1.Visible = false;
            label3.Visible = false;
            dateTimePicker2.Visible = false;
            Anul anul = new Anul();
            anul.Show();
            this.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            dateTimePicker1.Visible = false;    
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
