using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class Form1 : Form
    {
        private BindingList<Poruka> svePoruke = new BindingList<Poruka>();
        public Form1()
        {
            InitializeComponent();
            gbLoginKorisnika.Visible = true;
            gbSaljiSvima.Visible = false;
            gbSaljiOdredjenom.Visible = false;
            gbPoruke.Visible = false;
            try
            {
                Komunikacija.Instanca.Connect();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = new Korisnik
            {
                KorisnickoIme = txtIme.Text,
                KorisnickaSifra = txtSifra.Text
            };
            Poruka poruka = new Poruka
            {
                Posiljalac = korisnik,
                Operacija = Operacija.Login
            };
            Komunikacija.Instanca.PosaljiPoruku(poruka);
            Poruka odgovor = Komunikacija.Instanca.CitajPoruku();
            if (odgovor.Uspesno)
            {
                MessageBox.Show($"Dobrodosli {odgovor.Primalac.KorisnickoIme}");
                gbLoginKorisnika.Visible = false;
                gbSaljiSvima.Visible = true;
                gbSaljiOdredjenom.Visible = true;
                gbPoruke.Visible = true;
                SlusajPoruke();
            }
            else
            {
                MessageBox.Show("Neuspesna prijava pokusajte opet!");
            }
            this.Text = odgovor.Primalac.KorisnickoIme;
        }

        private void SlusajPoruke()
        {
            Thread nit = new Thread(ObradaPoruka);
            nit.Start();
        }

        private void ObradaPoruka()
        {
            try
            {
                while (true)
                {
                    Poruka odgovor = Komunikacija.Instanca.CitajPoruku();
                    switch (odgovor.Operacija)
                    {
                        case Operacija.Login:
                            Invoke(new Action(() =>
                            {
                                cbKorisnici.DataSource = odgovor.UlogovaniKorisnici;
                            }));
                            break;
                        case Operacija.SaljiSvima:
                            Invoke(new Action(() =>
                            {
                                if (svePoruke.Count < 3)
                                {
                                    svePoruke.Add(odgovor);
                                    dgvPoslednje3.DataSource = svePoruke;
                                    dgvPoslednje3.Columns["Uspesno"].Visible = false;
                                    dgvPoslednje3.Columns["Operacija"].Visible = false;
                                    ((DataGridViewTextBoxColumn)dgvPoslednje3.Columns["Tekst"]).MaxInputLength = 20;
                                }
                                else
                                {
                                    svePoruke.Add(odgovor);
                                    dgvOstale.DataSource = svePoruke.Take(svePoruke.Count - 3).ToList();
                                    dgvPoslednje3.DataSource = svePoruke.Except(svePoruke.Take(svePoruke.Count - 3).ToList()).ToList();
                                    dgvPoslednje3.Columns["Uspesno"].Visible = false;
                                    dgvPoslednje3.Columns["Operacija"].Visible = false;
                                    ((DataGridViewTextBoxColumn)dgvPoslednje3.Columns["Tekst"]).MaxInputLength = 20;
                                    dgvOstale.Columns["Uspesno"].Visible = false;
                                    dgvOstale.Columns["Operacija"].Visible = false;
                                    ((DataGridViewTextBoxColumn)dgvOstale.Columns["Tekst"]).MaxInputLength = 20;
                                }
                            }));
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (SerializationException)
            {
                Environment.Exit(0);
            }

        }

        private void btnSaljiSvima_Click(object sender, EventArgs e)
        {
            try
            {
                Poruka poruka = new Poruka
                {
                    Tekst = rtbPorukaZaSve.Text,
                    Primalac = new Korisnik
                    {
                        KorisnickoIme = "svi korisnici"
                    },
                    Operacija = Operacija.SaljiSvima
                };
                Komunikacija.Instanca.PosaljiPoruku(poruka);

            }
            catch (ServerCommunicationException)
            {
                MessageBox.Show("Doslo je do prekida komunikacije sa serverom");
                this.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSaljiKorisniku_Click(object sender, EventArgs e)
        {
            try
            {
                Poruka poruka = new Poruka
                {
                    Tekst = rtbPorukaZaKorisnika.Text,
                    Operacija = Operacija.SaljiSvima,
                    Primalac = (Korisnik)cbKorisnici.SelectedItem
                };
                Komunikacija.Instanca.PosaljiPoruku(poruka);
            }
            catch (ServerCommunicationException)
            {
                MessageBox.Show("Doslo je do prekida komunikacije sa serverom");
                this.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCitajPoruku_Click(object sender, EventArgs e)
        {
            if (dgvPoslednje3.SelectedRows.Count > 0)
            {
                Poruka poruka = (Poruka)dgvPoslednje3.SelectedRows[0].DataBoundItem;
                if (poruka.Tekst.Length > 20)
                {
                    MessageBox.Show(poruka.Tekst);
                }
                else MessageBox.Show("Tekst poruke ima do 20 karaktera");
            }
            else if (dgvOstale.SelectedRows.Count > 0)
            {
                Poruka poruka = (Poruka)dgvOstale.SelectedRows[0].DataBoundItem;
                if (poruka.Tekst.Length > 20)
                {
                    MessageBox.Show(poruka.Tekst);
                }
                else MessageBox.Show("Tekst poruke ima do 20 karaktera");
            }
        }
    }
}