using Biblioteka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerskiDeo
{
    public class Server
    {
        private Socket serverSoket;
        private List<ClinetHandler> clients = new List<ClinetHandler>();
        private List<Korisnik> korisnici = Kontroler.Instanca.VratiKorisnike();
        internal void Start()
        {
            if (serverSoket == null)
            {
                serverSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000));
                serverSoket.Listen(5);
            }
        }

        internal void ObradaKlijenata()
        {
            try
            {
                while (true)
                {
                    Socket klijentSoket = serverSoket.Accept();
                    ClinetHandler handler = new ClinetHandler(klijentSoket, clients, korisnici);
                    clients.Add(handler);
                    handler.OdjavljeniKlijent += Handler_OdjavljeniKlijent;
                    Thread klijentNit = new Thread(handler.ObradaZahteva);
                    klijentNit.Start();

                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Handler_OdjavljeniKlijent(object sender, EventArgs e)
        {
            clients.Remove((ClinetHandler)sender);
        }

        internal void Close()
        {

            serverSoket?.Close();
            serverSoket = null;
            foreach (var klijent in clients.ToList())
            {
                klijent.CloseSoket();
            }


        }
    }
}
