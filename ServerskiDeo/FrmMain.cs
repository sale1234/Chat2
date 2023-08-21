using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerskiDeo
{
    public partial class FrmMain : Form
    {
        private Server server;
        private List<Korisnik> korisnici = Kontroler.Instanca.VratiKorisnike();
        public FrmMain()
        {
            InitializeComponent();
            lblPodaci.Text = Kontroler.Instanca.Administartor.Ime.ToString() + " " + Kontroler.Instanca.Administartor.Prezime.ToString();
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            dgvKorisnici.DataSource = null;
            dgvKorisnici.DataSource = korisnici.ToList();
            dgvKorisnici.Refresh();
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            try
            {
                server = new Server();
                server.Start();
                MessageBox.Show("Server je pokrenut");
                Thread nit = new Thread(server.ObradaKlijenata);
                nit.Start();
                btnPokreni.Enabled = false;
                btnZaustavi.Enabled = true;
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            try
            {
                server?.Close();
                server = null;
                btnPokreni.Enabled = true;
                btnZaustavi.Enabled = false;
                MessageBox.Show("Server je zaustavljen");

            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
            }
        }

        private void btnDodajKorisnika_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = new Korisnik
            {
                KorisnickoIme = txtKorisnickoIme.Text,
                KorisnickaSifra = txtKorisnickaSifra.Text
            };
            if(korisnik.KorisnickoIme.All(Char.IsLetter) && korisnik.KorisnickaSifra.All(Char.IsLetterOrDigit) && korisnik.KorisnickaSifra.Any(Char.IsLetter) && korisnik.KorisnickaSifra.Any(Char.IsDigit) && korisnik.KorisnickaSifra.Length >= 2)
            {
                Kontroler.Instanca.DodajKorisnika(korisnik);
            }
            else MessageBox.Show("Niste lepo uneli vrednosti, korisnicko ime moze da sadrzi samo slova a korisnicka sifra mora da sadrzi bar jedno slovo i jedan broj");
        }
    }
}
