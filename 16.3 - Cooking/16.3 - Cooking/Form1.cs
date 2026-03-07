using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16._3___Cooking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.AllowDrop = true;
            pictureBox2.AllowDrop = true;
            pictureBox3.AllowDrop = true;
            pictureBox4.AllowDrop = true;
            pictureBox5.AllowDrop = true;
            pictureBox6.AllowDrop = true;
            pictureBox7.AllowDrop = true;
            pictureBox8.AllowDrop = true;
            pictureBox9.AllowDrop = true;
            pictureBox10.AllowDrop = true;
            pictureBox11.AllowDrop = true;
            pictureBox12.AllowDrop = true;

        }
        int contor = 0;
        string path = System.AppDomain.CurrentDomain.BaseDirectory;
        private void pictureBox7_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pic2 = (PictureBox)sender;
            if (pic2.Name != "pictureBox12")
                return;
            pic.Image = null;
            contor++;
            if(contor >= 4 && contor <= 8)
            {
                pictureBox12.Image = Image.FromFile(path + "bolPlin.jpg");
            }else if(contor == 10)
            {
                pictureBox12.Image = Image.FromFile(path + "bolGata.jpg");
                pictureBox12.Size = new Size(834, 269);
                pictureBox12.Location = new Point(28, 169);
            }
        }

        private void pictureBox7_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        PictureBox pic;

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            

            pic = (sender as PictureBox);
            if (e.Button == MouseButtons.Left) 
            {
                if (pic.Image != null && pic.Name != "PictureBox12")
                {
                    pic.DoDragDrop(pic.Image, DragDropEffects.Move);
                }
            }
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            PictureBox pic = (sender as PictureBox);
            ToolTip toolTip = new ToolTip();

            if (pic.Name == "pictureBox12")
            {
                toolTip.SetToolTip(pictureBox12, "Adaugati aici ingredientele");
            }
            else if (pic.Name == "pictureBox2")
            {
                toolTip.SetToolTip(pictureBox2, "Ardei");
            }
            else if (pic.Name == "pictureBox3")
            {
                toolTip.SetToolTip(pictureBox3, "Busuioc");
            }
            else if (pic.Name == "pictureBox4")
            {
                toolTip.SetToolTip(pictureBox4, "ceapa");
            }
            else if (pic.Name == "pictureBox5")
            {
                toolTip.SetToolTip(pictureBox5, "cimbru");
            }
            else if (pic.Name == "pictureBox6")
            {
                toolTip.SetToolTip(pictureBox6, "rosii");
            }
            else if (pic.Name == "pictureBox7")
            {
                toolTip.SetToolTip(pictureBox7, "zucchini");
            }
            else if (pic.Name == "pictureBox8")
            {
                toolTip.SetToolTip(pictureBox8, "vinete");
            }
            else if (pic.Name == "pictureBox9")
            {
                toolTip.SetToolTip(pictureBox9, "ceapa");
            }
            else if (pic.Name == "pictureBox10")
            {
                toolTip.SetToolTip(pictureBox10, "ulei");
            }
            else if (pic.Name == "pictureBox11")
            {
                toolTip.SetToolTip(pictureBox11, "sare si piper");
            }
        }
    }
}
