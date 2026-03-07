namespace Binar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text != "0")
            {
                label1.Text += button1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text != "0")
            {
                label1.Text += button2.Text;
            }
            else
            {
                label1.Text = "1";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            long number = Convert.ToInt64(label1.Text, 2);
            label2.Text = number.ToString();
        }
    }
}
