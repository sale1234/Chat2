using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskiDeo
{
    public class Kontroler
    {
        private static Kontroler instanca;

        private Kontroler()
        {

        }

        public static Kontroler Instanca 
        { 
            get
            {
                if (instanca == null) instanca = new Kontroler();
                return instanca;
            }
        }

        internal List<Korisnik> VratiKorisnike()
        {
            try
            {
                broker.OpenConnection();
                return broker.VratiKorisnike();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        private Broker broker = new Broker();

        public Administartor Administartor { get; set; }

        internal Administartor UlogujAdmina(Administartor administartor)
        {
            try
            {
                broker.OpenConnection();
                List<Administartor> lista = broker.VratiAdmine();
                foreach (var admin in lista)
                {
                    if(admin.Email == administartor.Email && admin.Sifra == administartor.Sifra)
                    {
                        Administartor = admin;
                        return admin;
                    }
                }
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        internal void DodajKorisnika(Korisnik korisnik)
        {
            try
            {
                broker.OpenConnection();
                broker.DodajKorisnika(korisnik);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        internal void DodajPoruku(Poruka poruka)
        {
            try
            {
                broker.OpenConnection();
                if (poruka.Tekst != null) broker.DodajPoruku(poruka);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
        private List<Korisnik> ulogovani = new List<Korisnik>();
        internal void UlogujKorisnika(Korisnik ulogovaniKorisnik)
        {
            ulogovani.Add(ulogovaniKorisnik);
        }

        internal List<Korisnik> VratiUlogovane()
        {
            return ulogovani;
        }
    }
}
