using System;
using SESockets;

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
            TCPClientComunicator client = new TCPClientComunicator();
            Console.Write("Digite o ip:");
            string ip = Console.ReadLine();
            Console.Write("Digite a porta:");
            int port = Convert.ToInt32(Console.ReadLine());
            client.SetWire(this);
            client.Connect(ip);
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

