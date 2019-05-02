using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace SESockets
{
    public interface Connection
    {

        void Connect(IPAddress iPAddress,int port);

        void Disconnect();

    }
}
