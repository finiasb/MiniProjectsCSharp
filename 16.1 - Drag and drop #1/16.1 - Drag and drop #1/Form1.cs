using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _16._1___Drag_and_drop__1
{
    public partial class Form1 : Form
    {

        private TabControl tabControlPrincipal;
        private TabPage tpCatalog, tpSetlist, tpStatistici, tpEgalizator;
        private Label lblUserEmail, lblInfoIesire;
        private Button btnDeconectare, btnIesire;

        public Form1( )
        {
            InitializeComponent();
            ConfigurareGenerala();
            CreareFilaCatalog();
            CreareFilaSetlist();
            CreareFilaStatistici();
            CreareFilaEgalizator();
        }

        private void ConfigurareGenerala()
        {
            this.Text = "SoundStage - Management Concert";
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(18, 18, 18);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblUserEmail = new Label
            {
                Text = "Utilizator: " ,
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Italic)
            };

            btnDeconectare = new Button
            {
                Text = "Deconectare",
                Location = new Point(750, 10),
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.IndianRed,
                FlatStyle = FlatStyle.Flat
            };

            btnIesire = new Button
            {
                Text = "✖ Ieșire Aplicație",
                Location = new Point(860, 10),
                BackColor = Color.Maroon,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 110
            };

            tabControlPrincipal = new TabControl
            {
                Location = new Point(20, 50),
                Size = new Size(945, 580),
                Appearance = TabAppearance.Normal
            };

            this.Controls.AddRange(new Control[] { lblUserEmail, btnDeconectare, btnIesire, tabControlPrincipal });
        }

        private void CreareFilaCatalog() // Cerința 5 [cite: 475, 476]
        {
            tpCatalog = new TabPage("Catalog piese");
            tpCatalog.BackColor = Color.FromArgb(25, 25, 25);

            ComboBox cmbGen = new ComboBox { Location = new Point(20, 20), Width = 150 }; // [cite: 477]
            Button btnFiltru = new Button { Text = "Filtrează Gen", Location = new Point(180, 18), BackColor = Color.MediumPurple }; // [cite: 480]

            NumericUpDown numMin = new NumericUpDown { Location = new Point(350, 20), Width = 60, Minimum = 40, Maximum = 240 };
            NumericUpDown numMax = new NumericUpDown { Location = new Point(420, 20), Width = 60, Minimum = 40, Maximum = 240 };
            Button btnBpm = new Button { Text = "Filtrează BPM", Location = new Point(490, 18) }; // [cite: 481]

            DataGridView dgv = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(900, 480),
                BackgroundColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.Black // Datele din tabel trebuie să fie lizibile
            };
            tpCatalog.Controls.AddRange(new Control[] { cmbGen, btnFiltru, numMin, numMax, btnBpm, dgv });
            tabControlPrincipal.TabPages.Add(tpCatalog);
        }

        private void CreareFilaSetlist() // Cerința 6 [cite: 485, 486]
        {
            tpSetlist = new TabPage("Setlist-ul meu");
            tpSetlist.BackColor = Color.FromArgb(25, 25, 25);

            TextBox txtEv = new TextBox { Location = new Point(20, 20), Width = 200, };
            txtEv.Text = "Nume eveniment";
            Button btnCreare = new Button { Text = "Creează eveniment", Location = new Point(230, 18), Width = 150 }; // [cite: 487]

            Label lblDurataTotala = new Label
            { // [cite: 490]
                Text = "Durata Totală: 00:00:00",
                ForeColor = Color.Cyan,
                Location = new Point(750, 20),
                Font = new Font("Consolas", 12, FontStyle.Bold)
            };

            tpSetlist.Controls.AddRange(new Control[] { txtEv, btnCreare, lblDurataTotala });
            tabControlPrincipal.TabPages.Add(tpSetlist);
        }

        private void CreareFilaStatistici() // Cerința 7 [cite: 494, 495]
        {
            tpStatistici = new TabPage("Statistici");
            TabControl tcStats = new TabControl { Dock = DockStyle.Fill };

            TabPage tpTop = new TabPage("Top Artiști"); // [cite: 496]
            Chart barChart = new Chart { Dock = DockStyle.Fill }; // [cite: 497]
            
            TabPage tpGen = new TabPage("Distribuție Gen"); // [cite: 499]
            Chart pieChart = new Chart { Dock = DockStyle.Fill }; // [cite: 500]
            
            tcStats.TabPages.Add(tpTop);
            tcStats.TabPages.Add(tpGen);
            tpStatistici.Controls.Add(tcStats);
            tabControlPrincipal.TabPages.Add(tpStatistici);
        }

        private void CreareFilaEgalizator() // Cerința 8 [cite: 502, 503]
        {
            tpEgalizator = new TabPage("Egalizator");
            tpEgalizator.BackColor = Color.FromArgb(20, 20, 20);

            PictureBox pbAnimatie = new PictureBox
            {
                Location = new Point(170, 80),
                Size = new Size(600, 300), // [cite: 508]
                BackColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button btnStart = new Button
            {
                Text = "▶ START",
                Location = new Point(350, 400),
                BackColor = Color.ForestGreen,
                ForeColor = Color.White
            };
            Button btnStop = new Button
            {
                Text = "■ STOP",
                Location = new Point(480, 400),
                Enabled = false,
                BackColor = Color.DimGray
            }; // [cite: 509]

            tpEgalizator.Controls.AddRange(new Control[] { pbAnimatie, btnStart, btnStop });
            tabControlPrincipal.TabPages.Add(tpEgalizator);
        }
    }
}
