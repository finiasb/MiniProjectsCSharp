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

namespace _08._2___Animatie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        bool merge = false;
        int index = 1;

        private async void button1_Click(object sender, EventArgs e)
        {
            if (merge)
            {
                merge = false;
                button1.Text = "Start";
                return;
            }

            merge = true;
            button1.Text = "Stop";

            while (merge)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + $"Images\\{index}.gif";

                pictureBox1.Image = Image.FromFile(path);

                index++;
                if (index > 12)
                    index = 1;

                await Task.Delay(1000 / trackBar1.Value);
            }
        }

    }
}
