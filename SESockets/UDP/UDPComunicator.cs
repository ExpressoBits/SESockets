using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace SESockets.UDP
{
    public abstract class UDPComunicator : Comunicator
    {

        public virtual void DisconnectClient(UdpClient client)
        {
            Disconnect();
            client.Close();
        }

    }
}
