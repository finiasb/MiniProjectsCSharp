using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._2_Charts
{
    public partial class Materii : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Charts.mdf"";Integrated Security=True;Connect Timeout=30";

        public Materii()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            incarcare();
        }

        private void Materii_Load(object sender, EventArgs e)
        {

        }
        private void incarcare()
        {

            chart1.Series["Nota"].Points.Clear();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Nume, Romana, Matematica from Elevi", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                int minM = 1000;
                int maxM = 0;
                int minR = 1000;
                int maxR = 0;
                while (rdr.Read())
                {
                    string nume = rdr[0].ToString();
                    int romana = Convert.ToInt32(rdr[1].ToString());
                    int mate = Convert.ToInt32(rdr[2].ToString());

                    if(mate < minM)
                        minM = mate;
                    if(mate > maxM)
                        maxM = mate;

                    if (romana < minR)
                        minR = romana;
                    if (romana > maxR)
                        maxR = romana;


                    if (comboBox1.SelectedIndex == 0)
                    {

                        chart1.Series["Nota"].Points.AddXY(nume, mate);
                    }
                    else
                    {
                        chart1.Series["Nota"].Points.AddXY(nume, romana);

                    }

                }
                if(comboBox1.SelectedIndex == 0) 
                {
                    chart1.ChartAreas[0].AxisY.Minimum = minM;
                    chart1.ChartAreas[0].AxisY.Maximum = maxM;

                }
                else
                {

                    chart1.ChartAreas[0].AxisY.Minimum = minR;
                    chart1.ChartAreas[0].AxisY.Maximum = maxR;
                }
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            incarcare();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adauga adauga = new adauga();
            adauga.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
