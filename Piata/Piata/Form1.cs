using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piata
{
    public partial class Form1 : Form
    {
        string path = System.AppDomain.CurrentDomain.BaseDirectory;
        Dictionary<int, Image> imagini = new Dictionary<int, Image>();
        int suma = 894;
        Dictionary<int, int> BaniDict = new Dictionary<int, int>();
        Dictionary<int, int> BaniTotal = new Dictionary<int, int>();
        int sumaToate = 886;

        public Form1()
        {
            InitializeComponent();
            BaniTotal[1] = 0;
            BaniTotal[5] = 0;
            BaniTotal[10] = 0;
            BaniTotal[20] = 0;
            BaniTotal[50] = 0;
            BaniTotal[100] = 0;
            BaniTotal[200] = 0;
            BaniTotal[500] = 0;
        }

        void platire()
        {
            suma = int.Parse(textBox1.Text);
            suma -= sumaToate;
            BaniTotal[500]++;
            BaniTotal[200]++;
            BaniTotal[100]++;
            BaniTotal[50]++;
            BaniTotal[20]++;
            BaniTotal[10]++;
            BaniTotal[5]++;
            BaniTotal[1]++;
            BaniDict[500]--;
            BaniDict[200]--;
            BaniDict[100]--;
            BaniDict[50]--;
            BaniDict[20]--;
            BaniDict[10]--;
            BaniDict[5]--;
            BaniDict[1]--;


            while (suma > 0)
            {
                if (suma >= 500 && BaniDict[500] >= 1)
                {
                    suma -= 500;
                    BaniDict[500]--;
                    BaniTotal[500]++;
                }
                else if (suma >= 200 && BaniDict[200] >= 1)
                {
                    suma -= 200;
                    BaniTotal[200]++;
                    BaniDict[200]--;
                }
                else if (suma >= 100 && BaniDict[100] >= 1)
                {
                    BaniDict[100]--;
                    BaniTotal[100]++;
                    suma -= 100;
                }
                else if (suma >= 50 && BaniDict[50] >= 1)
                {
                    BaniDict[50]--;
                    BaniTotal[50]++;
                    suma -= 50;
                }
                else if (suma >= 20 && BaniDict[20] >= 1)
                {
                    BaniDict[20]--;
                    BaniTotal[20]++;
                    suma -= 20;
                }
                else if (suma >= 10 && BaniDict[10] >= 1)
                {
                    BaniDict[10]--;
                    BaniTotal[10]++;
                    suma -= 10;
                }
                else if (suma >= 5 && BaniDict[5] >= 1)
                {
                    BaniTotal[5]++;
                    BaniDict[5]--;
                    suma -= 5;
                }
                else if (suma >= 1 && BaniDict[1] >= 1)
                {
                    BaniDict[1]--;
                    BaniTotal[1]++;
                    suma -= 1;
                }
            }
        }


        void citire()
        {
            BaniDict.Clear();
            imagini.Clear();
            StreamReader rdr = new StreamReader(filePath);
            string line;
            int i = 1;
            while ((line = rdr.ReadLine()) != null)
            {
                string[] c = line.Split(' ');

                Image img = Image.FromFile(path + c[1]);

                if (c[1] == "1.png")
                {
                    BaniDict.Add(1, int.Parse(c[0]));
                    imagini.Add(1, img);
                }
                else if (c[1] == "5.png")
                {
                    imagini.Add(5, img);
                    BaniDict.Add(5, int.Parse(c[0]));
                }
                else if (c[1] == "10.png")
                {
                    imagini.Add(10, img);
                    BaniDict.Add(10, int.Parse(c[0]));
                }
                else if (c[1] == "20.png")
                {
                    imagini.Add(20, img);
                    BaniDict.Add(20, int.Parse(c[0]));
                }
                else if (c[1] == "50.png")
                {
                    imagini.Add(50, img);
                    BaniDict.Add(50, int.Parse(c[0]));
                }
                else if (c[1] == "100.png")
                {
                    imagini.Add(100, img);
                    BaniDict.Add(100, int.Parse(c[0]));
                }
                else if (c[1] == "200.png")
                {
                    imagini.Add(200, img);
                    BaniDict.Add(200, int.Parse(c[0]));
                }
                else if (c[1] == "500.png")
                {
                    imagini.Add(500, img);
                    BaniDict.Add(500, int.Parse(c[0]));
                }
            }

            if (BaniDict[1] >= 1)
            {
                pictureBox1.Image = imagini[1];
                label1.Text = BaniDict[1] + " X";
            }

            if (BaniDict[5] >= 1)
            {
                pictureBox2.Image = imagini[5];
                label2.Text = BaniDict[5] + " X";
            }

            if (BaniDict[10] >= 1)
            {
                pictureBox3.Image = imagini[10];
                label3.Text = BaniDict[10] + " X";
            }

            if (BaniDict[20] >= 1)
            {
                pictureBox4.Image = imagini[20];
                label4.Text = BaniDict[20] + " X";
            }

            if (BaniDict[50] >= 1)
            {
                pictureBox5.Image = imagini[50];
                label5.Text = BaniDict[50] + " X";
            }

            if (BaniDict[100] >= 1)
            {
                pictureBox6.Image = imagini[100];
                label6.Text = BaniDict[100] + " X";
            }

            if (BaniDict[200] >= 1)
            {
                pictureBox7.Image = imagini[200];
                label7.Text = BaniDict[200] + " X";
            }

            if (BaniDict[500] >= 1)
            {
                pictureBox8.Image = imagini[500];
                label8.Text = BaniDict[500] + " X";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is PictureBox && this.Controls[i].Tag?.ToString() == "bani")
                    this.Controls.RemoveAt(i);
            }

            BaniTotal[1] = 0;
            BaniTotal[5] = 0;
            BaniTotal[10] = 0;
            BaniTotal[20] = 0;
            BaniTotal[50] = 0;
            BaniTotal[100] = 0;
            BaniTotal[200] = 0;
            BaniTotal[500] = 0;

            citire();

            platire();

            int x = 350, y = 70;

            while (BaniTotal[500] > 0)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                pic.Size = new Size(80, 50);
                pic.Image = imagini[500];
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pic);
                pic.Tag = "bani";
                BaniTotal[500]--;

                if (y > 500)
                {
                    y = 70;
                    x += 110;
                }
                y += 80;
            }

            while (BaniTotal[200] > 0)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                pic.Size = new Size(80, 50);
                pic.Image = imagini[200];
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Tag = "bani";
                this.Controls.Add(pic);

                BaniTotal[200]--;

                if (y > 500)
                {
                    y = 70;
                    x += 110;
                }
                y += 80;
            }

            while (BaniTotal[100] > 0)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                pic.Size = new Size(80, 50);
                pic.Image = imagini[100];
                pic.Tag = "bani";
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pic);

                BaniTotal[100]--;

                if (y > 500)
                {
                    y = 70;
                    x += 110;
                }
                y += 80;
            }

            while (BaniTotal[50] > 0)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                pic.Tag = "bani";
                pic.Size = new Size(80, 50);
                pic.Image = imagini[50];
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pic);

                BaniTotal[50]--;

                if (y > 500)
                {
                    y = 70;
                    x += 110;
                }
                y += 80;
            }

            while (BaniTotal[20] > 0)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                pic.Size = new Size(80, 50);
                pic.Image = imagini[20];
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Tag = "bani";
                this.Controls.Add(pic);

                BaniTotal[20]--;

                if (y > 500)
                {
                    y = 70;
                    x += 110;
                }
                y += 80;
            }

            while (BaniTotal[10] > 0)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                pic.Tag = "bani";
                pic.Size = new Size(80, 50);
                pic.Image = imagini[10];
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pic);

                BaniTotal[10]--;

                if (y > 500)
                {
                    y = 70;
                    x += 110;
                }
                y += 80;
            }

            while (BaniTotal[5] > 0)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                pic.Size = new Size(80, 50);
                pic.Image = imagini[5];
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pic);
                pic.Tag = "bani";

                BaniTotal[5]--;

                if (y > 500)
                {
                    y = 70;
                    x += 110;
                }
                y += 80;
            }

            while (BaniTotal[1] > 0)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                pic.Size = new Size(80, 50);
                pic.Image = imagini[1];
                pic.Tag = "bani";
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pic);

                BaniTotal[1]--;

                if (y > 500)
                {
                    y = 70;
                    x += 110;
                }
                y += 80;
            }
        }
        string filePath;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = path;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                citire();

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            suma = int.Parse(textBox1.Text);
        }
    }
}
