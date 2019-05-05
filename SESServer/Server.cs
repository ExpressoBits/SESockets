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
                server = new TCPComunicator(true);
            }

            else //(type == Utils.ConnectionType.UDP)
            {
                server = new UDPComunicator(true);
            }

            server.SetWire(this);
            server.Connect(null);

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
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length));
        }
    }
}

