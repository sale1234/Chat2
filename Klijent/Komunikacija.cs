using Biblioteka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    public class Komunikacija
    {
        private static Komunikacija instanca;
        private Socket soket;
        private CommunicationHelper helper;

        private Komunikacija()
        {

        }

        public static Komunikacija Instanca
        {
            get
            {
                if (instanca == null) instanca = new Komunikacija();
                return instanca;
            }
        }

        internal void Connect()
        {
            try
            {
                soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                soket.Connect("127.0.0.1", 9000);
                helper = new CommunicationHelper(soket);
            }
            catch (SocketException ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        internal void PosaljiPoruku(Poruka poruka)
        {
            try
            {
                helper.PosaljiPoruku(poruka);

            }
            catch (Exception)
            {
                throw new ServerCommunicationException();
            }
        }

        internal Poruka CitajPoruku()
        {
            return helper.CitajPoruku<Poruka>();
        }
    }
}
