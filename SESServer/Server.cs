using System;
using SESockets;
using SESockets.Utils;

namespace SESockets.Server
{
    class Server : WireConnection
    {
        static void Main()
        {
            new Server();

            Console.WriteLine("Enter any to quit...");
            Console.ReadLine();
        }

        public Server()
        {
            TCPServerComunicator server = new TCPServerComunicator();
            server.SetWire(this);
            server.Connect(IPUtils.GetLocalIP());
        }


        public void Log(string text)
        {
            Console.WriteLine("[LOG]" + text);
        }

        public void Receive(string text)
        {
            Console.WriteLine(text);
        }

        public void Send(string text)
        {
            Console.WriteLine(text);
        }
    }
}

