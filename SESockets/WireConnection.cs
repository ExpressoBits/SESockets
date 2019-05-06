using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace SESockets
{
    public interface WireConnection
    {

        void Send(byte[] bytes);

        void Receive(byte[] bytes);

        void Log(string text);

        //Chamado após efetuar conexão com servidor ou cliente
        void OnConnectToServer(IPAddress ip);

        //Chamado após criar server
        void OnCreateServer(IPAddress ip);

        //Chamado quando um cliente conecta no server
        void OnClientConnectToServer(IPAddress ip);


    }
}
