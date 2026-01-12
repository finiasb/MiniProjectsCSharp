using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalog
{
    public partial class Form1 : Form
    {
        List<Nota> note = new List<Nota>();

        private int c = 0;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a utiliza Catalogul, prima data va trebui sa incarcati elevii din fisierul extern.");
        }

        private void inchideAplicatiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void incarcaEleviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.InitialDirectory = path;
            openFileDialog1.Title = "Incarca elevii";
            openFileDialog1.FileName = "elevi.txt";
            openFileDialog1.Filter = "Text documents (*.txt) |*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(filePath);
                string linie;

                while((linie = sr.ReadLine()) != null)
                {
                    comboBox1.Items.Add(linie);
                    c++;
                }
            }
            label1.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            textBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            button1.Enabled = true;
            comboBox1.SelectedIndex = 0;

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text documents (*.txt) |*.txt";
            saveFileDialog1.Title = "Salveaza informatiile despre elevi";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "rezultate";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;


                StreamWriter writer = new StreamWriter(filePath);
                for (int i = 0; i < note.Count; i++)
                {
                    string info = String.Format("Elevul {0} a primit nota {2} pe data de {1}", note[i].Nume, note[i].Data, note[i].Note);
                    writer.WriteLine(info);
                }
                writer.Close();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int note3))
            {
                MessageBox.Show("Introduceți doar un număr valid pentru nota!");
                textBox1.Text = "";
                return;
            }
            int note2 = Int32.Parse(textBox1.Text);
            DateTime dt = dateTimePicker1.Value;
            string nume = comboBox1.Text;
            
            Nota n = new Nota()
            {
                Nume = nume,
                Note = note2,
                Data = dt
            };

            note.Add(n);

            MessageBox.Show($"Nota adăugata cu succes");
        }
    }
}
