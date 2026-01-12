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

namespace _06._1_Login_form
{
    public partial class Form1 : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\DBtema.mdf"";Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreareCont cont = new CreareCont();
            cont.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM utilizatori WHERE username = @user AND parola = @parola", con);

                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@parola", textBox2.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    MessageBox.Show("Autentificare reușită!");
                    this.Hide();
                    Aplicatie app = new Aplicatie();
                    app.Show();
                }
                else
                {
                    MessageBox.Show("Username sau parolă incorecte!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

    }
}
