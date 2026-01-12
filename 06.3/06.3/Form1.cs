using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _06._3
{
    public partial class Form1 : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Magazinut.mdf"";Integrated Security=True;Connect Timeout=30";
        private int id;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProduse();
        }

        private void LoadProduse()
        {
            comboBox1.Items.Clear();

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Nume, Stoc FROM Produse", con);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr["Nume"].ToString());
                }
                rdr.Close();
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            else
                label2.Text = "Stoc: ---";
        }

        private void UpdateStocSiID(string numeProdus)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Stoc FROM Produse WHERE Nume = @nume", con);
                cmd.Parameters.AddWithValue("@nume", numeProdus);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    id = rdr["Id"] != DBNull.Value ? Convert.ToInt32(rdr["Id"]) : 0;
                    int stocInt = rdr["Stoc"] != DBNull.Value ? Convert.ToInt32(rdr["Stoc"]) : 0;
                    label2.Text = $"Stoc: {stocInt}";
                }
                rdr.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStocSiID(comboBox1.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            label3.Visible = label4.Visible = button5.Visible = button6.Visible =
            textBox2.Visible = textBox3.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e) 
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                if (int.TryParse(textBox3.Text, out int numar))
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Produse (Nume, Stoc) VALUES (@nume, @stoc)", con);
                        cmd.Parameters.AddWithValue("@nume", textBox2.Text);
                        cmd.Parameters.AddWithValue("@stoc", numar);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Adaugare efectuata cu succes");
                    textBox2.Text = textBox3.Text = "";
                    LoadProduse();
                }
                else
                {
                    MessageBox.Show("In categoria stoc introduceti un numar");
                }
            }
            else
            {
                MessageBox.Show("Nu lasati campuri necompletate");
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            label3.Visible = label4.Visible = button5.Visible = button7.Visible =
            textBox2.Visible = textBox3.Visible = true;
            button6.Visible = false;

            textBox2.Text = comboBox1.SelectedItem.ToString();
            comboBox1.Enabled = false;

            UpdateStocSiID(textBox2.Text);
            textBox3.Text = label2.Text.Replace("Stoc: ", "");
        }

        private void button7_Click(object sender, EventArgs e) 
        {
            if (int.TryParse(textBox3.Text, out int numar))
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Produse SET Nume=@nume, Stoc=@stoc WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@nume", textBox2.Text);
                    cmd.Parameters.AddWithValue("@stoc", numar);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Editare efectuata cu succes");
                LoadProduse();
            }
            else
            {
                MessageBox.Show("Stocul trebuie sa fie un numar");
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Produse WHERE Nume = @nume", con);
                cmd.Parameters.AddWithValue("@nume", comboBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Produs sters");
            LoadProduse();
        }

        private void button5_Click(object sender, EventArgs e) 
        {
            label3.Visible = label4.Visible = button5.Visible = button6.Visible =
            button7.Visible = textBox2.Visible = textBox3.Visible = false;
            comboBox1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
