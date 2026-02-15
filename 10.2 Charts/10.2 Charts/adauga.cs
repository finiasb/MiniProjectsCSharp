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
    public partial class adauga : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Charts.mdf"";Integrated Security=True;Connect Timeout=30";

        public adauga()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int mate, romana;
            bool doarLitere = textBox1.Text.All(char.IsLetter);
            if (!doarLitere)
            {
                MessageBox.Show("TextBox1 trebuie să conțină doar litere!");
                textBox1.Text = string.Empty;
                return;
            }
            if (!Int32.TryParse(textBox2.Text, out mate) || !Int32.TryParse(textBox3.Text, out romana))
            {
                MessageBox.Show("Date Invalide");

                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                return;
            }
            if (Int32.TryParse(textBox2.Text, out mate) && Int32.TryParse(textBox3.Text, out romana))
            {
                using(SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Elevi(Nume, Romana, Matematica) values(@nume, @romana, @mate)", con);
                    cmd.Parameters.AddWithValue("@nume", textBox1.Text);
                    cmd.Parameters.AddWithValue("@romana", romana.ToString());
                    cmd.Parameters.AddWithValue("@mate", mate.ToString());
                    cmd.ExecuteNonQuery();
                }
                this.Hide();
                Materii materii = new Materii();    
                materii.Show(); 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void adauga_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Materii materii = new Materii();
            materii.Show();
        }
    }
}
