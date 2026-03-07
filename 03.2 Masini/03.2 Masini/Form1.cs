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

namespace Masini
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> model = new Dictionary<string, string>();
        Dictionary<string, string> fisier = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();

            model["Mercedes"] = "Maybach";
            fisier["Mercedes"] = "maybach.jpg";
            model["BMW"] = "Seria 7";
            fisier["BMW"] = "bmw_seria7.jpg";
            model["Porche"] = "Cayenne Coupe";
            fisier["Porche"] = "cayennecoupe.jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + @"\masini.txt";
            StreamReader sr = new StreamReader(path);
            string linie;
            char[] split = { '#' };
            while ((linie = sr.ReadLine()) != null)
            {
                string[] sir = linie.Split(split);
                comboBox1.Items.Add(sir[0]);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = model[comboBox1.SelectedItem.ToString()];
            string name = fisier[comboBox1.SelectedItem.ToString()]; 
            string path = AppDomain.CurrentDomain.BaseDirectory + @"data\" + "masini.txt";
            pictureBox1.Image = Image.FromFile(path);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
