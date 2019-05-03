﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace SESockets.TCP
{
    public abstract class TCPComunicator : Comunicator
    {

        public virtual void DisconnectClient(TcpClient client)
        {
            Disconnect();
            client.Close();
        }

    }
}
