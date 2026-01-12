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

namespace _05._4_Masini
{
    public partial class Form1 : Form
    {
        private int id;
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Masini.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False";
        private bool ok = true;    
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ok)
            {
                comboBox1.Items.Clear();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select NumeMasina from Masini", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["NumeMasina"].ToString());
                    }
                    reader.Close();
                }
                comboBox1.SelectedIndex = 0;
                MessageBox.Show("Masinile s au incarcat cu succes");
                ok = false;
            }
            else
            {
                MessageBox.Show("Ati incarcat deja");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string nume = comboBox1.SelectedItem.ToString();
                SqlCommand cmd1 = new SqlCommand("Select Id_Masina from Masini where NumeMasina = @nume", con);
                cmd1.Parameters.AddWithValue("@nume", nume);
                SqlDataReader r = cmd1.ExecuteReader();
                if(r.Read())
                {
                    id = Convert.ToInt32(r[0].ToString());
                }r.Close();
                
                SqlCommand cmd = new SqlCommand("Select Model from ModeleMasini where Id_Masina = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["Model"].ToString());
                }
                reader.Close();
            }
            comboBox2.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string model = comboBox2.SelectedItem.ToString();
                SqlCommand cmd = new SqlCommand("Select Cale from ModeleMasini where Model = @model", con);
                cmd.Parameters.AddWithValue("@model", model);

                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    string path = System.AppDomain.CurrentDomain.BaseDirectory + @"\images\" + reader["Cale"].ToString();
                    pictureBox1.Image = Image.FromFile(path);
                }
                reader.Close();
            }
        }
    }

}
