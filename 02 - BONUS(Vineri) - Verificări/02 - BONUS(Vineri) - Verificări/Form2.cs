using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vineri
{
    public partial class Form2 : Form
    {
        
        private List<string> list = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sirInitial = textBox1.Text;
            string alfabetMare = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alfabetMic = "abcdefghijklmnopqrstuvwxyz";
            string cifre = "0123456789";

            list.Clear(); // foarte important

            foreach (char s in sirInitial)
            {
                if (Char.IsUpper(s))
                {
                    int x = (int)s % 26;
                    list.Add(alfabetMare[x].ToString());
                }
                else if (Char.IsLower(s))
                {
                    int x = (int)s % 26;
                    list.Add(alfabetMic[x].ToString());
                }
                else if (Char.IsDigit(s))
                {
                    int x = (int)s % 10;
                    list.Add(cifre[x].ToString());
                }
                else
                {
                    // caractere speciale sau spații - le păstrăm neschimbate
                    list.Add(s.ToString());
                }
            }

            string sirNou = string.Join("", list);
            label1.Text = sirNou;
        }

    }
}
