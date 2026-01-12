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

namespace _05._2_Bilete_SQL
{
    public partial class Form1 : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\bilete.mdf"";Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from autor where Gen_Literar = 'Proza' ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string denumire = reader["Denumire"].ToString();
                    string autor = reader["Autor"].ToString();

                    dataGridView1.Rows.Add(autor, denumire);
                }
                reader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from autor where pret > 35 ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string denumire = reader["Denumire"].ToString();
                    string autor = reader["Autor"].ToString();

                    dataGridView1.Rows.Add(autor, denumire);
                }
                reader.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from elevi where varsta >= 17 and varsta <= 18 ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string nume = reader["Nume"].ToString();
                    string prenume = reader["Prenume"].ToString();

                    dataGridView2.Rows.Add(nume, prenume);
                }
                reader.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from elevi order by media Desc", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string nume = reader["Nume"].ToString();
                    string prenume = reader["Prenume"].ToString();

                    dataGridView2.Rows.Add(nume, prenume);
                }
                reader.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from [Table]  where Nr_calorii >=200", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string denumire = reader["Denumire"].ToString();

                    dataGridView3.Rows.Add(denumire);
                }
                reader.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from [Table]  order by Categorie asc", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string denumire = reader["Categorie"].ToString();

                    dataGridView4 .Rows.Add(denumire);
                }
                reader.Close();
            }
        }
    }
}
