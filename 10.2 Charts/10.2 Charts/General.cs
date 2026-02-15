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
    public partial class General : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Charts.mdf"";Integrated Security=True;Connect Timeout=30";
        public General()
        {
            InitializeComponent();
            incarcare();
        }

        private void General_Load(object sender, EventArgs e)
        {

        }
        private void incarcare()
        {
            using(SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Nume, Romana, Matematica from Elevi", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string nume = rdr[0].ToString();
                    int romana = Convert.ToInt32(rdr[1].ToString());
                    int mate = Convert.ToInt32(rdr[2].ToString());

                    chart1.Series["Romana"].Points.AddXY(nume, romana);
                    chart1.Series["Matematica"].Points.AddXY(nume, mate);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
