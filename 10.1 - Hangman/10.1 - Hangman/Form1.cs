using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._1___Hangman
{
    public partial class Form1 : Form
    {
        bool bio = false, geografie = false, info = false, romana = false, masini = false;  
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked || checkBox5.Checked) 
            {
                if(checkBox1.Checked)
                    bio = true;
                if(checkBox2.Checked)
                    geografie = true;
                if(checkBox3.Checked)
                    info = true;
                if(checkBox4.Checked)
                    romana = true;
                if(checkBox5.Checked)
                    masini = true;


                hangman hangman = new hangman(bio, geografie, info, romana, masini);
                hangman.Show();
                this.Hide();    
            }
            else
            {
                MessageBox.Show("Nu ati selectat nici o categorie");
            }
        }
    }
}
