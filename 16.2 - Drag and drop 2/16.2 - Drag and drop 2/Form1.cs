using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16._2___Drag_and_drop_2
{
    public partial class DragAndDrop : Form
    {
        public DragAndDrop()
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;
            pictureBox2.AllowDrop = true;
            pictureBox3.AllowDrop = true;
            pictureBox4.AllowDrop = true;
            textBox1.AllowDrop = true;
            textBox2.AllowDrop = true;
            this.AllowDrop = true;
        }
        PictureBox pic;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pic = (PictureBox)sender;

            if (e.Button == MouseButtons.Left)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.DoDragDrop(pictureBox1.Image, DragDropEffects.Move);
                }
                else if (pictureBox2.Image != null)
                {
                    pictureBox2.DoDragDrop(pictureBox2.Image, DragDropEffects.Move);
                }
                else if (pictureBox3.Image != null)
                {
                    pictureBox3.DoDragDrop(pictureBox3.Image, DragDropEffects.Move);
                }
                else if (pictureBox4.Image != null)
                {
                    pictureBox4.DoDragDrop(pictureBox4.Image, DragDropEffects.Move);
                }
            }
        }
        TextBox txt;
        private void pictureBox2_DragEnter(object sender, DragEventArgs e)
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

        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            if (pb == pic)
                return;

            if (pb.Image != null)
                return;

            pb.Image = pic.Image;
            pic.Image = null;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox == txt)
                return;


            textBox.Text = txt.Text;
            txt.Text = string.Empty;

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            txt = (TextBox)sender;

            if (textBox1.Text != null)
            {
                textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Move);
            }
            else if(textBox2.Text != null)
            {
                textBox2.DoDragDrop(textBox2.Text, DragDropEffects.Move);
            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
