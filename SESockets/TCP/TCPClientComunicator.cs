using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace SESockets
{
    public class TCPClientComunicator : TCPComunicator
    {

        TcpClient client;
        
        public override void Connect(IPAddress ip, int port)
        {
            base.Connect(ip, port);
            client = new TcpClient();
            client.Connect(ip, port);
            Run();
        }

        public void Run()
        {
            Init(client.GetStream());

            string text = reader.ReadString();

            wireConnection.Log(text);

            DisconnectClient(client);
        }

        public void Send(string text)
        {
            writer.Write(text);
        }

        

        

    }
}
