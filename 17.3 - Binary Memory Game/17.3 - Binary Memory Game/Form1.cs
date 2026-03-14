using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace _17._3___Binary_Memory_Game
{
    public partial class Form1 : Form
    {
        List<int> listNumere = new List<int>();
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            lista();
        }


        private void lista()
        {
            for (int i = 2; i <= 9; i++)
            {
                listNumere.Add(i);
                listNumere.Add(Int32.Parse(Convert.ToString(i, 2)));
            }

            listNumere = listNumere.OrderBy(ax => rnd.Next()).ToList();
            int x = 0, y = 0;
            for (int i = 1; i <= 16; i++)
            {
                if (i == 5 || i == 9 || i == 13 )
                {
                    x = 0;
                    y += 75;
                }
                Button btn = new Button();
                btn.Text = "?";
                btn.Name = $"btn{i}";
                btn.Location = new Point(x, y);
                btn.Size = new Size(75, 75);
                btn.BackColor = Color.LightGreen;
                this.Controls.Add(btn);
                btn.Click += btn_click;
                btn.Tag = listNumere[i- 1].ToString();
                x += 75;
            }
        }
        
        Button primu = null;
        Button doi = null;
        bool gasit = false;
        int cnt = 0;

        private async void btn_click(object sender, EventArgs e)
        {
            if (gasit) 
                return;

            Button btn = (Button)sender;
            if (btn.Text != "?") return; 

            btn.Text = btn.Tag.ToString();

            if (primu == null)
            {
                primu = btn;
                return;
            }

            doi = btn;
            gasit = true;

            await Task.Delay(1000);

            int val1 = ConvertToDecimal(primu.Tag.ToString());
            int val2 = ConvertToDecimal(doi.Tag.ToString());

            if (val1 == val2)
            {
                primu.Enabled = false;
                doi.Enabled = false;
                cnt++;
                label1.Text = "Scor: " + cnt;
                if(cnt == 8)
                {
                    MessageBox.Show("Felicitari, ati castigat");
                    System.Environment.Exit(0);
                }
            }
            else
            {
                primu.Text = "?";
                doi.Text = "?";
            }

            primu = null;
            doi = null;
            gasit = false;
        }

        private int ConvertToDecimal(string s)
        {
            int x;
            if (s[0] == '0' || s[0] == '1')
                x = Convert.ToInt32(s, 2);
            else
                x = Convert.ToInt32(s, 10);

            return x;
        }

    }
    
}
