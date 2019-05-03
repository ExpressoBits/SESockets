using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace SESockets.TCP
{
    public abstract class TCPComunicator : Comunicator
    {
        /// <summary>
        /// Desconecta o cliente
        /// </summary>
        /// <param name="client"></param>
        public virtual void DisconnectClient(TcpClient client)
        {
            Disconnect();
            client.Close();
        }

    }
}
