using System;
using SESockets;
using SESockets.TCP;
using SESockets.UDP;
using SESockets.Utils;
using System.Net;

namespace SESockets.Client
{
    class Client : WireConnection
    {
        public Comunicator client;

        static void Main()
        {
            new Client();

            Console.WriteLine("Enter any to quit...");
            Console.ReadLine();
        }

        public Client()
        {
            
            ConnectionType type = ConnectionType();

            Console.Clear();
            Console.WriteLine("Connection type = " + type);

            if (type == Utils.ConnectionType.TCP)
            {
                client = new TCPComunicator(false);
            }

            else //(type == Utils.ConnectionType.UDP)
            {
                client = new UDPComunicator(false);
            }


            Console.Write("Digite o ip:");
            string ip = Console.ReadLine();
            Console.Write("Digite a porta:");
            int port = Convert.ToInt32(Console.ReadLine());
            client.SetWire(this);
            client.Connect(IPUtils.GetIP(ip));

            bool exit = false;
            while (!exit)
            {
                Console.Write(">");
                string t = Console.ReadLine();
                if (t == "quit")
                {
                    exit = true;
                }
                else
                {
                    Send(System.Text.Encoding.ASCII.GetBytes(t));
                }

                
            }
            client.Disconnect();

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


        public void Log(string message)
        {
            Console.WriteLine("[LOG]" + message);
        }

        public void Receive(byte[] bytes)
        {
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length));
        }

        public void Send(byte[] bytes)
        {
            client.Send(bytes);
        }

        public void OnConnectToServer(IPAddress ip)
        {
            Log("Connect to " + ip + " with sucess!");
        }

        public void OnCreateServer(IPAddress ip)
        {
            Log("Create server IP:" + ip + " with sucess!");
        }

        public void OnClientConnectToServer(IPAddress ip)
        {
            Log("Client IP:" + ip + " connect!");
        }
    }
}

