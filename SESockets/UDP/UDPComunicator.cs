using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace SESockets.UDP
{
    public abstract class UDPComunicator : Comunicator
    {
        /// <summary>
        /// Desconecta o cliente
        /// </summary>
        /// <param name="client"></param>
        public void DisconnectClient(UdpClient client)
        {
            Disconnect();
            client.Close();
        }

    }
}
