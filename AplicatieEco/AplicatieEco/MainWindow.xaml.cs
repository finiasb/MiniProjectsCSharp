using System;
using System.Collections.ObjectModel;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;

namespace AplicatieEco
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<InregistrareEco> ListaInregistrari { get; set; }

        public ChartValues<int> ValoriGrafic { get; set; }
        public ObservableCollection<string> EticheteZile { get; set; }
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            EcranIntroducere.Visibility = Visibility.Collapsed; 
        }
        public MainWindow()
        {
            InitializeComponent();

            ListaInregistrari = new ObservableCollection<InregistrareEco>();
            ValoriGrafic = new ChartValues<int>();
            EticheteZile = new ObservableCollection<string>();

            PopuleazaDateInitiale();

            dgDateEco.ItemsSource = ListaInregistrari;

            liveChartEco.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Scor Eco",
                    Values = ValoriGrafic,
                    PointGeometrySize = 10,
                    Stroke = System.Windows.Media.Brushes.ForestGreen,
                    Fill = System.Windows.Media.Brushes.Transparent
                }
            };

            axaX.Labels = EticheteZile;

            dpData.SelectedDate = DateTime.Today;
        }

        private void PopuleazaDateInitiale()
        {
            int scor1 = 100 - (int)(150 * 0.2 + 5.2 * 0.3 + 12.0 * 0.5);
            int scor2 = 100 - (int)(200 * 0.2 + 8.1 * 0.3 + 45.0 * 0.5);
            int scor3 = 100 - (int)(120 * 0.2 + 4.0 * 0.3 + 0.0 * 0.5);
            int scor4 = 100 - (int)(180 * 0.2 + 6.5 * 0.3 + 15.0 * 0.5);
            int scor5 = 100 - (int)(160 * 0.2 + 5.0 * 0.3 + 5.0 * 0.5);

            AdaugaInListe(DateTime.Now.AddDays(-4), 150, 5.2, 12.0, scor1);
            AdaugaInListe(DateTime.Now.AddDays(-3), 200, 8.1, 45.0, scor2);
            AdaugaInListe(DateTime.Now.AddDays(-2), 120, 4.0, 0.0, scor3);
            AdaugaInListe(DateTime.Now.AddDays(-1), 180, 6.5, 15.0, scor4);
            AdaugaInListe(DateTime.Now, 160, 5.0, 5.0, scor5);
        }

        private void AdaugaInListe(DateTime data, double apa, double energie, double transport, int scor)
        {
            ListaInregistrari.Add(new InregistrareEco(data, apa, energie, transport, scor));
            ValoriGrafic.Add(scor);
            EticheteZile.Add(data.ToString("dd.MM"));
        }

        private void BtnAdauga_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime data = dpData.SelectedDate ?? DateTime.Now;
                double apa = double.Parse(txtApa.Text);
                double energie = double.Parse(txtEnergie.Text);
                double transport = double.Parse(txtTransport.Text);

                int scor = 100 - (int)(apa * 0.2 + energie * 0.3 + transport * 0.5);
                if (scor < 0) scor = 0;

                AdaugaInListe(data, apa, energie, transport, scor);

                if (transport > 30)
                    lblRecomandare.Text = "Ai mers mult cu mașina azi!";
                else if (energie > 7)
                    lblRecomandare.Text = "Consum mare de curent!";
                else
                    lblRecomandare.Text = "Bravo! Ai avut o zi foarte verde.";

                txtApa.Clear();
                txtEnergie.Clear();
                txtTransport.Clear();
            }
            catch
            {
                MessageBox.Show("Valorile nu sunt valide!", "Eroare validare", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    public class InregistrareEco
    {
        public DateTime Data { get; set; }
        public double Apa { get; set; }
        public double Energie { get; set; }
        public double Transport { get; set; }
        public int ScorEco { get; set; }

        public InregistrareEco(DateTime data, double apa, double energie, double transport, int scor)
        {
            Data = data;
            Apa = apa;
            Energie = energie;
            Transport = transport;
            ScorEco = scor;
        }
    }
}