using System;
using System.Collections.Generic;
using System.Text;

namespace SESockets
{
    public interface WireConnection
    {

        void Send(string text);

        void Receive(string text);

        void Log(string text);

    }
}
