using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SESockets.UDP
{
    public abstract class UDPComunicator : Comunicator
    {

        public IPEndPoint endPoint;


        public override void Connect(IPAddress ip, int port)
        {
            base.Connect(ip, port);
            endPoint = new IPEndPoint(ip, port);
        }

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
