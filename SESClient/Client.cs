using System;
using SESockets;
using SESockets.TCP;
using SESockets.UDP;
using SESockets.Utils;

namespace SESockets.Client
{
    class Client : WireConnection
    {
        static void Main()
        {
            new Client();

            Console.WriteLine("Enter any to quit...");
            Console.ReadLine();
        }

        public Client()
        {
            Comunicator client;
            ConnectionType type = ConnectionType();

            Console.Clear();
            Console.WriteLine("Connection type = " + type);

            if (type == Utils.ConnectionType.TCP)
            {
                client = new ClientTCPComunicator();
            }

            else //(type == Utils.ConnectionType.UDP)
            {
                client = new ClientUDPComunicator();
            }


            Console.Write("Digite o ip:");
            string ip = Console.ReadLine();
            Console.Write("Digite a porta:");
            int port = Convert.ToInt32(Console.ReadLine());
            client.SetWire(this);
            client.Connect(ip);
        }

        public ConnectionType ConnectionType()
        {
            Console.WriteLine("Connection Type:");
            Console.WriteLine("1. TCP");
            Console.WriteLine("2. UDP");
            Console.Write("Enter to type server:");
            int type = Convert.ToInt32(Console.ReadLine());
            return type == 1 ? Utils.ConnectionType.TCP : Utils.ConnectionType.UDP;
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

