using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17._2___Magazin__DGW_cu_imagini_
{
    public partial class Form1 : Form
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Dispozitive.mdf"";Integrated Security=True;Connect Timeout=30";
        string path = System.AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();
          //  sterg2e();
            incarcaredgv();
        }

        private void sterg2e()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("truncate table Gadgets", con);
                cmd.ExecuteNonQuery();
            }
        }
        void incarcaredgv()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Gadgets", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] imgData = (byte[])reader[3];
                    MemoryStream ms2 = new MemoryStream(imgData);
                    Image img = Image.FromStream(ms2);
                    dataGridView1.RowTemplate.Height = 50;
                    dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), img);
                }
            }
        }
        List<int> idUri = new List<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = path;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                string filePath = openFileDialog1.FileName;
                textBox3.Text = filePath;   
                pictureBox1.Image = Image.FromFile(filePath);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                bool bifat = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = !bifat;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int numarCod;
            if (!Int32.TryParse(textBox1.Text, out numarCod))
            {
                MessageBox.Show("Codul trebuie sa fie un numar");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("puneti o denumire");
                return;
            }
            using(SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from Gadgets where cod=@cod", con);
                cmd.Parameters.AddWithValue("@cod", numarCod);

                int exista = (int)cmd.ExecuteScalar();
                if (exista > 0)
                {
                    MessageBox.Show("Id-ul exista deja");
                    return;
                }
            }
            dataGridView1.Rows.Clear();

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] data = ms.ToArray();

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Gadgets(cod, denumire, cale, imagine) values(@cod, @denumire, @cale, @imagine)", con);
                cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                cmd.Parameters.AddWithValue("@denumire", textBox2.Text);
                cmd.Parameters.AddWithValue("@cale", textBox3.Text);
                cmd.Parameters.AddWithValue("@imagine", data);
                cmd.ExecuteNonQuery();
                idUri.Add(numarCod);
            }

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Gadgets", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] imgData = (byte[])reader[3];
                    MemoryStream ms2 = new MemoryStream(imgData);
                    Image img = Image.FromStream(ms2);
                    dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), img);
                    dataGridView1.RowTemplate.Height = 50;
                }
            }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool bifat = Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value);
                if (bifat)
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("delete from gadgets where cod = @cod", con);
                        cmd.Parameters.AddWithValue("@cod", Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
                        cmd.ExecuteNonQuery();
                    }
                }
                
            }
            dataGridView1.Rows.Clear();

            incarcaredgv();

        }
    }
}
