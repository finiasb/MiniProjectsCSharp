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

namespace _06._2___Fitness_small_app
{
    public partial class Form1 : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Fitness.mdf"";Integrated Security=True;Connect Timeout=30";
        string copieNume;
        string kilo;
        int id;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from Utilizatori where nume = @nume", con);
            cmd.Parameters.AddWithValue("@nume", textBox1.Text);
            int count = (int)cmd.ExecuteScalar();
            if (count == 1)
            {
                
                SqlCommand cmd2 = new SqlCommand("Select Id, kg from Utilizatori where nume = @nume", con);
                cmd2.Parameters.AddWithValue("@nume", textBox1.Text);
                SqlDataReader red = cmd2.ExecuteReader();
                if (red.Read())
                {
                    string id2 = red[0].ToString();
                    string kgg = red["kg"].ToString();
                    id = Int32.Parse(id2);
                    kilo = kgg;
                    textBox3.Text = kgg;
                }red.Close();
                textBox2.Text = textBox1.Text;
                copieNume = textBox1.Text;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                MessageBox.Show("Utilizatorul nu exista");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button2.Visible = false;
            button3.Visible = true;
            button1.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string numeNou = textBox2.Text;
                string kgNoi = textBox3.Text;
                int numar = 0;
                if(int.TryParse(kgNoi, out numar))
                {
                    SqlCommand cmd = new SqlCommand("Update utilizatori Set nume = @nume, kg = @kg2 where id = @id2", con);
                    cmd.Parameters.AddWithValue("@nume", numeNou);
                    cmd.Parameters.AddWithValue("@kg2", numar.ToString());
                    cmd.Parameters.AddWithValue("@id2", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Editare efectuata cu succes");

                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    button2.Visible = true;
                    button3.Visible = false;
                    button1.Enabled = true;
                    textBox1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("In categoria kg introduceti un numar");
                }
            }
            else
            {
                MessageBox.Show("Nu lasati campuri necompletate");
            }
            
            
        }
    }
}
