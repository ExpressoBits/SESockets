using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace SESockets
{
    public interface Connection
    {

        void Connect(IPAddress ip);

        void SetWire(WireConnection wireConnection);

        void Send(byte[] bytes);

        void Disconnect();

    }
}
