using Biblioteka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerskiDeo
{
    public class ClinetHandler
    {
        private Socket klijentSoket;
        private List<ClinetHandler> clients;
        private CommunicationHelper helper;
        private List<Korisnik> korisnici;
        

        public ClinetHandler(Socket klijentSoket, List<ClinetHandler> clients, List<Korisnik> korisnici)
        {
            this.klijentSoket = klijentSoket;
            this.clients = clients;
            this.korisnici = korisnici;
            helper = new CommunicationHelper(klijentSoket);
            
        }

       

        internal void ObradaZahteva()
        {
            try
            {
                while(!kraj)
                {
                    Poruka poruka = helper.CitajPoruku<Poruka>();
                    switch (poruka.Operacija)
                    {
                        case Operacija.Login:
                            Login(poruka);
                            break;
                        case Operacija.SaljiSvima:
                            SaljiSvima(poruka);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if(klijentSoket != null)
                CloseSoket();
            }
        }

        private void SaljiSvima(Poruka poruka)
        {
            poruka.Posiljalac = UlogovaniKorisnik;
            Kontroler.Instanca.DodajPoruku(poruka);
            foreach (var klijent in clients)
            {
                if (klijent.UlogovaniKorisnik != null) klijent.helper.PosaljiPoruku(poruka);
            }
        }
        public Korisnik UlogovaniKorisnik { get; set; }

        private void Login(Poruka poruka)
        {
            try
            {
                bool ulogovan = false;
                foreach (var korisnik in korisnici)
                {
                    if (poruka.Posiljalac.KorisnickoIme == korisnik.KorisnickoIme && poruka.Posiljalac.KorisnickaSifra == korisnik.KorisnickaSifra)
                    {
                        ulogovan = true;
                        UlogovaniKorisnik = korisnik;
                    }
                }
                if (ulogovan)
                {
                    korisnici.Remove(UlogovaniKorisnik);
                    Kontroler.Instanca.UlogujKorisnika(UlogovaniKorisnik);

                    Poruka odgovor = new Poruka
                    {
                        Primalac = UlogovaniKorisnik,
                        Uspesno = true
                    };
                    helper.PosaljiPoruku(odgovor);
                    Poruka zaSve = new Poruka
                    {
                        UlogovaniKorisnici = Kontroler.Instanca.VratiUlogovane()
                    };
                    SaljiSvima(zaSve);
                }
                else
                {
                    Poruka odgovor = new Poruka
                    {
                        Uspesno = false
                    };
                    helper.PosaljiPoruku(odgovor);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        private object lockObject = new object();
        private bool kraj = false;
        public EventHandler OdjavljeniKlijent;
        

        internal void CloseSoket()
        {
            try
            {
                lock (lockObject)
                {
                    if (klijentSoket != null)
                    {
                        kraj = true;
                        klijentSoket.Shutdown(SocketShutdown.Both);
                        klijentSoket.Close();
                        klijentSoket = null;
                        OdjavljeniKlijent?.Invoke(this, EventArgs.Empty);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>" + ex.Message);
            }

        }
    }
}
