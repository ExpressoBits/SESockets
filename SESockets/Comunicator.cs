using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SESockets
{
    public abstract class Comunicator : Connection
    {
        public WireConnection wireConnection;
        public bool isServer;


        public abstract void Connect(IPAddress ip);

        public abstract void Send(byte[] bytes);

        public abstract void Disconnect();


        public void SetWire(WireConnection wireConnection)
        {
            this.wireConnection = wireConnection;
        }

        public void Receive(byte[] bytes)
        {
            wireConnection.Receive(bytes);
        }
    }
}
