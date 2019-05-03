using System;
using SESockets;
using SESockets.Utils;
using SESockets.TCP;
using SESockets.UDP;

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
            Comunicator server;
            ConnectionType type = ConnectionType();

            Console.Clear();
            Console.WriteLine("Connection type = " + type);

            if (type == Utils.ConnectionType.TCP)
            {
                server = new ServerTCPComunicator();
            }
               
            else //(type == Utils.ConnectionType.UDP)
            {
                server = new ServerUDPComunicator();
            }

            server.SetWire(this);
            server.Connect(IPUtils.GetLocalIP());
            

            
        }

        public ConnectionType ConnectionType()
        {
            Console.WriteLine("Connection Type:");
            Console.WriteLine("1. TCP");
            Console.WriteLine("2. UDP");
            Console.Write("Enter to type server:");
            int type = Convert.ToInt32(Console.ReadLine());
            return type==1?Utils.ConnectionType.TCP:Utils.ConnectionType.UDP;
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

