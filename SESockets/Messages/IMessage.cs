using System;
using System.Collections.Generic;
using System.Text;

namespace SESockets.Messages
{
    //Implementa um interface para mensagem enviadas de sockets
    public interface IMessage
    {

        MessageType Type { get; }

    }
}
