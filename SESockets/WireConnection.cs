using System;
using System.Collections.Generic;
using System.Text;

namespace SESockets
{
    public interface WireConnection
    {

        void Send(byte[] bytes);

        void Receive(byte[] bytes);

        void Log(string text);

    }
}
