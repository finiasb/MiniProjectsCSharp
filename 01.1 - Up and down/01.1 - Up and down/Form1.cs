namespace Up_and_down
{
    public partial class Form1 : Form
    {
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count--;
            label1.Text = "Count: " + count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            label1.Text = "Count: " + count;
        }
    }
}
