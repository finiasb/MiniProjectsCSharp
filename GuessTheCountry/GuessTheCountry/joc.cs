using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheCountry
{
    public partial class joc : Form
    {
        private List<string> NumeTari = new List<string>();
        private List<string> Capitala = new List<string>();
        private List<string> PozaJpg = new List<string>();
        int intrebareRandom;
        int x = 0;
        int nrIntrebare = 1;
        int scor = 0;
        private string path = AppDomain.CurrentDomain.BaseDirectory;

        public joc()
        {
            InitializeComponent();
        }

        private void joc_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(path + @"\date.txt");
            string linie;
            var rnd = new Random();
            char[] split = { '#' };
            while ((linie = sr.ReadLine()) != null)
            {
                string[] sir = linie.Split(split);
                NumeTari.Add(sir[0]);
                Capitala.Add(sir[1]);
                PozaJpg.Add(sir[2]);
                x++;
            }

            foreach (string s in NumeTari)
            {
                comboBox1.Items.Add(s);
            }
            comboBox1.SelectedIndex = 0;
            intrebareRandom = rnd.Next(0, x);
            pictureBox1.Image = Image.FromFile(path + $"\\images\\{PozaJpg[intrebareRandom]}");
            label3.Text = $"Intrebarea {nrIntrebare} / 5";
            label4.Text = $"Scor: {scor}";
            label2.Visible = false;
            pictureBox1.Tag = path + $"\\images\\{PozaJpg[intrebareRandom]}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string combo = comboBox1.Text;
            var rnd = new Random();

            label2.Visible = false;

            if (combo == NumeTari[intrebareRandom] && nrIntrebare == 5)
            {
                scor++;
                label4.Text = $"Scor: {scor}";
            }
            if (nrIntrebare == 5)
            {
                MessageBox.Show($"Testul s-a inchiat, ati obtinut {scor} puncte");
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
            if (combo == NumeTari[intrebareRandom] && nrIntrebare != 5)
            {
                scor++;
                nrIntrebare++;
                label3.Text = $"Intrebarea {nrIntrebare} / 5";
                label4.Text = $"Scor: {scor}";
                comboBox1.Items.Remove(NumeTari[intrebareRandom]);
                NumeTari.RemoveAt(intrebareRandom);
                Capitala.RemoveAt(intrebareRandom);
                PozaJpg.RemoveAt(intrebareRandom);
                comboBox1.SelectedIndex = 0;
                x--;
                intrebareRandom = rnd.Next(0, x);
                pictureBox1.Image = Image.FromFile(path + $"\\images\\{PozaJpg[intrebareRandom]}");
                MessageBox.Show("Raspuns Corect!");
            }
            else if (combo != NumeTari[intrebareRandom] && nrIntrebare != 5)
            {
                nrIntrebare++;
                label3.Text = $"Intrebarea {nrIntrebare} / 5";
                label4.Text = $"Scor: {scor}";
                comboBox1.Items.Remove(NumeTari[intrebareRandom]);
                NumeTari.RemoveAt(intrebareRandom);
                Capitala.RemoveAt(intrebareRandom);
                PozaJpg.RemoveAt(intrebareRandom);
                comboBox1.SelectedIndex = 0;
                x--;
                intrebareRandom = rnd.Next(0, x);
                pictureBox1.Image = Image.FromFile(path + $"\\images\\{PozaJpg[intrebareRandom]}");
                MessageBox.Show("Raspuns Gresit!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.Text = $"Capitala este la : {Capitala[intrebareRandom]}";
        }
    }
}
