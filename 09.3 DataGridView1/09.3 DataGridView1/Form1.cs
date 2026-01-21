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

namespace _09._3_DataGridView1
{
    public partial class Form1 : Form
    {
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Catalog.mdf"";Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id, clasa;
            string nume = textBox2.Text;
            string prenume = textBox3.Text;

            if (!Int32.TryParse(textBox1.Text, out id) || !Int32.TryParse(textBox4.Text, out clasa))
            {
                MessageBox.Show("ID sau clasa nu sunt valabile.");
                return;
            }

            if (!EsteDoarLitere(nume) || !EsteDoarLitere(prenume))
            {
                MessageBox.Show("Nume și prenume trebuie să conțină doar litere.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT Elev ON; Insert into Elev(idElev, nume, prenume, clasa) values(@idElev, @nume, @prenume, @clasa) SET IDENTITY_INSERT Elev OFF;", con);

                    cmd.Parameters.AddWithValue("@idElev", id);
                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@prenume", prenume);
                    cmd.Parameters.AddWithValue("@clasa", clasa);

                    cmd.ExecuteNonQuery();
                }

                dataGridView1.Rows.Add(id, nume, prenume, clasa);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) 
                {
                    MessageBox.Show("ID-ul există deja. Alege un alt ID.");
                }
                else
                {
                    MessageBox.Show("Eroare SQL: " + ex.Message);
                }
            }

        }
        private bool EsteDoarLitere(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        private void load()
        {
            using(SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Elev", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string id = reader[0].ToString();
                    string nume = reader[1].ToString();
                    string prenume = reader[2].ToString();  
                    string clasa = reader[3].ToString();

                    dataGridView1.Rows.Add(id, nume, prenume, clasa);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;

                int id = Int32.Parse(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Elev where idElev = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }


                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            int id = Int32.Parse(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
            string nume = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            string prenume = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            int clasa = Int32.Parse(dataGridView1.Rows[rowIndex].Cells[3].Value.ToString());

            textBox1.Text = id.ToString();
            textBox2.Text = nume;
            textBox3.Text = prenume;
            textBox4.Text = clasa.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateElev(id2, nume2, prenume2, clasa2);

        }
        private void UpdateElev(int id, string nume, string prenume, int clasa)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Elev SET nume = @nume, prenume = @prenume, clasa = @clasa WHERE idElev = @id",
                    con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nume", nume);
                cmd.Parameters.AddWithValue("@prenume", prenume);
                cmd.Parameters.AddWithValue("@clasa", clasa);

                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        int id2, clasa2;
        string nume2, prenume2;   
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Preluăm datele din rândul modificat
            id2 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idElev"].Value);
            nume2 = dataGridView1.Rows[e.RowIndex].Cells["nume"].Value.ToString();
            prenume2 = dataGridView1.Rows[e.RowIndex].Cells["prenume"].Value.ToString();
            clasa2 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clasa"].Value);

            // Apelăm funcția de update
        }
    }
}
