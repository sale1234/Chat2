using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class CommunicationHelper
    {
        private Socket soket;
        private NetworkStream stream;
        private BinaryFormatter formatter;

        public CommunicationHelper(Socket soket)
        {
            this.soket = soket;
            stream = new NetworkStream(soket);
            formatter = new BinaryFormatter();
        }

        public void PosaljiPoruku<T>(T poruka) where T : class
        {
            formatter.Serialize(stream, poruka);
        }

        public T CitajPoruku<T>() where T : class
        {

                return (T)formatter.Deserialize(stream);
        }
    }
}
