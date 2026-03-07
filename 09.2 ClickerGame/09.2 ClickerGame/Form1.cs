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

namespace JocPatratele
{
    public partial class Form1 : Form
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HighScore.mdf;Integrated Security=True;Connect Timeout=30";
        Random rnd = new Random();
        int scor = 0;
        int viteza = 1000;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GenereazaPatrat();
        }
        private void GenereazaPatrat()
        {
            int size = rnd.Next(20, 61);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = size;
            pictureBox.Height = size;

            int x = rnd.Next(0, this.Width - size);
            int y = rnd.Next(0, this.Height - size);

            pictureBox.Location = new Point(x, y);

            if (rnd.Next(0, 2) == 0)
                pictureBox.BackColor = Color.Green;
            else
                pictureBox.BackColor = Color.Red;

            pictureBox.Click += pictureBox1_Click;

            this.Controls.Add(pictureBox);

            VerificaJoc();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox currentPictureBox = (PictureBox)sender;

            if (currentPictureBox.BackColor == Color.Green)
                scor++;
            else
                scor--;

            label2.Text = "Scor: " + scor;
            this.Controls.Remove(currentPictureBox);

            if (scor > 0 && scor % 5 == 0)
            {
                viteza = Math.Max(100, viteza / 2); 
                timer1.Interval = viteza;
            }

            VerificaJoc();
        }
        private void VerificaJoc()
        {
            int verzi = 0;

            foreach (Control c in this.Controls)
            {
                if (c is PictureBox pb && pb.BackColor == Color.Green)
                    verzi++;
            }

            if (verzi >= 5)
            {
                timer1.Stop();
                MessageBox.Show("Joc terminat! Ai " + scor + " puncte.");
                using(SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Scores(scor) values(@scor)", con);
                    cmd.Parameters.AddWithValue("@scor", scor);
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select Top 1 scor from Scores", con);
                    SqlDataReader rdr = cmd.ExecuteReader();    
                    if(rdr.Read())
                    {
                        label3.Text = "HS: " + rdr[0].ToString();
                    }
                }
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Scor: ";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Top 1 scor from Scores", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label3.Text = "HS: " + rdr[0].ToString();
                }
            }
        }
    }
}
