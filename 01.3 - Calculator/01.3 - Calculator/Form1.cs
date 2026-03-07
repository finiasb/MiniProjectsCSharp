namespace Calculator
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private string operatorr = "";
        private bool ok = false;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }
        private void button_click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string buttonText = button.Text;

            if (ok)
            {
                textBox1.Text = "";
                ok = false;
            }

            if (textBox1.Text == "0" && buttonText == "0")
                return;

            if (textBox1.Text == "0" && char.IsDigit(buttonText[0]))
            {
                textBox1.Text = buttonText;
                return;
            }

            textBox1.Text += buttonText;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            operatorr = button.Text;
            firstNumber = Convert.ToDouble(textBox1.Text);
            ok = true;
        }
        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (ok)
            {
                textBox1.Text = "0";
                ok = false;
            }

            if (!textBox1.Text.Contains("."))
                textBox1.Text += ".";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            double secondNumber = Convert.ToDouble(textBox1.Text);
            double result = 0;

            switch (operatorr)
            {
                case "+": result = firstNumber + secondNumber; break;
                case "-": result = firstNumber - secondNumber; break;
                case "X": result = firstNumber * secondNumber; break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                        MessageBox.Show("Împărțirea la 0 nu este permisă!");
                    break;
            }

            textBox1.Text = result.ToString();
            firstNumber = result;
            ok = true;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            x *= -1;
            textBox1.Text = x.ToString();
        }

        private void radical_click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            if (x > 0)
            {
                double a = Math.Sqrt(x);
                textBox1.Text = a.ToString();
            }
            else
            {
                MessageBox.Show("trebuie sa fie un numar negativ");
                return;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            firstNumber = 0;
            operatorr = "";
            ok = false;
            textBox1.Text = "0";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double a = x * x;
            textBox1.Text = a.ToString();
        }
    }
}
