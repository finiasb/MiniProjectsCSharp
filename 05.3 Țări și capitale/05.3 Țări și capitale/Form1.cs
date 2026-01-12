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

namespace _05._3_Țări_și_capitale
{
    public partial class Form1 : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\TariSiCapitale.mdf"";Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select tari from informatii", con);
                SqlDataReader rdr = cmd.ExecuteReader();    
                while(rdr.Read()) 
                {
                    comboBox1.Items.Add(rdr["tari"].ToString());
                }rdr.Close();   
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string tara = comboBox1.SelectedItem.ToString();   
                SqlCommand cmd = new SqlCommand("Select capitale from informatii where tari = @tara", con);
                cmd.Parameters.AddWithValue("@tara", tara);

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label1.Text = rdr["capitale"].ToString();
                }
                rdr.Close();
            }
        }
    }
}
