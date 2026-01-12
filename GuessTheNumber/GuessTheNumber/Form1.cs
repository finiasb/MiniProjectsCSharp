using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GuessTheNumber
{
    public partial class Form1 : Form
    {
        Random Random = new Random();
        private int x;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numar;
            if (int.TryParse(textBox2.Text, out numar))
            {
                int numarMax = Int32.Parse(textBox2.Text);

                x = Random.Next(1, numarMax);
                Form2 Form = new Form2(x);
                Form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("introduceti un numar");
                textBox2.Clear();
            }
        }
    }
}
