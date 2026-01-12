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
    public partial class CreareCont : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\DBtema.mdf"";Integrated Security=True;Connect Timeout=30";

        public CreareCont()
        {
            InitializeComponent();
        }

        private void CreareCont_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM utilizatori WHERE username = @user", con);
            checkCmd.Parameters.AddWithValue("@user", textBox1.Text);
            int exists = (int)checkCmd.ExecuteScalar();

            if (exists > 0)
            {
                MessageBox.Show("Username-ul există deja!");
                return;
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO utilizatori(username, parola) VALUES(@username, @pass)", con);

            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Cont creat cu succes!");
            this.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
        }

    }
}
