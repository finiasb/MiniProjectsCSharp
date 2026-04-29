using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace ExchangeRate_API
{
    public partial class Form1 : Form
    {
        private API_Obj exchangeData;

        public Form1()
        {
            InitializeComponent();
        }
        private async void buttonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                double amount = double.Parse(textBoxAmount.Text);
                string from = comboBoxFrom.SelectedItem.ToString();
                string to = comboBoxTo.SelectedItem.ToString();

                // calculăm raportul dintre valute
                double fromRate = exchangeData.conversion_rates[from];
                double toRate = exchangeData.conversion_rates[to];

                double result = amount / fromRate * toRate;

                labelResult.Text = $"{amount} {from} = {result:F2} {to}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string url = "https://v6.exchangerate-api.com/v6/a1ed31d9b25d88da3b36e938/latest/USD";

            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(url);
                exchangeData = JsonConvert.DeserializeObject<API_Obj>(json);

                // Populăm comboBox-urile cu toate valutele
                foreach (var currency in exchangeData.conversion_rates.Keys)
                {
                    comboBoxFrom.Items.Add(currency);
                    comboBoxTo.Items.Add(currency);
                }

                // Setăm default
                comboBoxFrom.SelectedItem = "USD";
                comboBoxTo.SelectedItem = "RON";
            }
        }
    }
}
