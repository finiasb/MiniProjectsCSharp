namespace FormeMultiple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            if (!string.IsNullOrEmpty(nume))
            {
                Natura natura = new Natura(textBox1.Text);
                natura.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("introdu un nume");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            if(!string.IsNullOrEmpty(nume))
            {
                Planete planete = new Planete(textBox1.Text);
                planete.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("introdu un nume");
            }
        }
    }
}
