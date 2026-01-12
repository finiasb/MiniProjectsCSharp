namespace Vineri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox1.Text, out x))
            {


                x = Int32.Parse(textBox1.Text);
                if (IsPrime(x))
                {
                    MessageBox.Show("numarul este prim");
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("numarul nu este prim");
                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("introdu un numar valid");
                textBox1.Clear();
            }
        }

        private static bool IsPrime(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox2.Text, out x))
            {
                x = Int32.Parse(textBox2.Text);
                if (x % 2 == 0)
                {
                    MessageBox.Show("numarul este par");
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("numarul este impar");
                    textBox2.Clear();
                }
            }
            else
            {
                MessageBox.Show("introdu un numar valid");
                textBox2.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}
