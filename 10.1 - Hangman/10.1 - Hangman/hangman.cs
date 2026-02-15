using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._1___Hangman
{
    public partial class hangman : Form
    {
        bool _bio = false, _geografie = false, _info = false, _romana = false, _masini = false;
        private string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\hangman.mdf"";Integrated Security=True;Connect Timeout=30";
        string cuvantAles;
        List <int> nrRandom = new List<int> ();
        List<char> litereGhicite = new List<char>();
        int poza = 1;
        private void hangman_Load(object sender, EventArgs e)
        {

        }

        private async void button9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            char litera = btn.Text.ToLower()[0];
            btn.Visible = false;

            bool gasit = false;

            for (int i = 0; i < cuvantAles.Length; i++)
            {
                if (char.ToLower(cuvantAles[i]) == litera)
                {
                    gasit = true;
                    if (!litereGhicite.Contains(litera))
                        litereGhicite.Add(litera);
                }
            }

            if (!gasit)
            {
                poza++;
                if(poza == 7)
                {
                    string path = System.AppDomain.CurrentDomain.BaseDirectory;
                    pictureBox1.Image = Image.FromFile(path + $"{poza}.png");
                    MessageBox.Show("Ai pierdut");
                    pictureBox1.Image = Image.FromFile(path + $"8.png");
                    await Task.Delay(1000);
                    System.Environment.Exit(0);

                }
                else
                {
                    string path = System.AppDomain.CurrentDomain.BaseDirectory;
                    pictureBox1.Image = Image.FromFile(path + $"{poza}.png");
                }
            }

            bool castigat = true;
            for (int i = 0; i < cuvantAles.Length; i++)
            {
                if (!litereGhicite.Contains(char.ToLower(cuvantAles[i])))
                {
                    castigat = false;
                    break;
                }
            }

            Invalidate();
            if (castigat)
            {
                MessageBox.Show("Ai câștigat!");
                System.Environment.Exit(0);
            }

        }


        private void hangman_Paint(object sender, PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(cuvantAles))
                return;

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 3);
            Font font = new Font("Arial", 24, FontStyle.Bold);

            int nrLitere = cuvantAles.Length;
            int x1 = 200, y1 = 200, x2 = 230, y2 = 200;

            for (int i = 0; i < nrLitere; i++)
            {
                g.DrawLine(pen, x1, y1, x2, y2);

                if (litereGhicite.Contains(char.ToLower(cuvantAles[i])))
                {
                    g.DrawString(cuvantAles[i].ToString(), font, Brushes.Black, x1, y1 - 40);
                }

                x1 += 40;
                x2 += 40;
            }
        }


        Random rnd = new Random();
        public hangman(bool bio, bool geografie , bool info, bool romana, bool masini)
        {
            InitializeComponent();
            _bio = bio;
            _geografie = geografie;
            _info = info;
            _romana = romana;
            _masini = masini;
            alegeCuvant();
            MessageBox.Show(cuvantAles);
        }
        private void alegeCuvant()
        {
            nrRandom.Clear ();
            if (_bio)
                nrRandom.Add(rnd.Next(1, 6));     
            if (_geografie)
                nrRandom.Add(rnd.Next(6, 11));   
            if (_info)
                nrRandom.Add(rnd.Next(11, 16));   
            if (_romana)
                nrRandom.Add(rnd.Next(16, 21));
            if (_masini)
                nrRandom.Add(rnd.Next(21, 26));    


            int numarCuvant = nrRandom[rnd.Next(0, nrRandom.Count)];


            using (SqlConnection con =  new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Cuvant from Cuvinte where Id = @id", con);
                cmd.Parameters.AddWithValue("@id", numarCuvant);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cuvantAles = reader[0].ToString();
                }reader.Close();
            }
        }


    }
}
