namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int Player1 = 0, Player2 = 0;
        private List<Image> images = new List<Image>();
        public Form1()
        {
            InitializeComponent();
            images.Add(pictureBox1.Image);
            images.Add(pictureBox2.Image);
            images.Add(pictureBox3.Image);

            label1.Text = "Player 1: " + Player1;

            label2.Text = "Player 2: " + Player2;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = pictureBox1.Image;
            int x = random.Next(0, 3);
            pictureBox5.Image = images[x];
            if(x == 0)
            {
                label3.Text = "Egalitate";
            }else if (x == 1)
            {
                Player1++;
                label1.Text = "Player 1: " + Player1;
                label3.Text = "Castiga: Player1";

            }
            else if (x == 2)
            {
                Player2++;
                label2.Text = "Player 2: " + Player2;
                label3.Text = "Castiga: Player2";

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = pictureBox2.Image;
            int x = random.Next(0, 3);
            pictureBox5.Image = images[x];
            if (x == 1)
            {
                label3.Text = "Egalitate";
            }
            else if (x == 2)
            {
                Player1++;
                label1.Text = "Player 1: " + Player1;
                label3.Text = "Castiga: Player1";

            }
            else if (x == 0)
            {
                Player2++;
                label3.Text = "Castiga: Player2";

                label2.Text = "Player 2: " + Player2;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = pictureBox3.Image;
            int x = random.Next(0, 3);
            pictureBox5.Image = images[x];
            if (x == 2)
            {
                label3.Text = "Egalitate";
            }
            else if (x == 0)
            {
                Player1++;
                label1.Text = "Player 1: " + Player1;
                label3.Text = "Castiga: Player1";
            }
            else if (x == 1)
            {
                Player2++;
                label2.Text = "Player 2: " + Player2;
                label3.Text = "Castiga: Player2";

            }
        }
    }
}
