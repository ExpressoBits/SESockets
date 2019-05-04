using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace SESockets.TCP
{
    public class ClientTCPComunicator : TCPComunicator
    {

        TcpClient server;


        
        public override void Connect(IPAddress ip, int port)
        {
            base.Connect(ip, port);
            server = new TcpClient();
            server.Connect(ip,port);
            connected = true;
            Run();
        }

        public void Run()
        {
            Init(server.GetStream());

            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.Start();

            string t = "";
            while (t != "END")
            {
                Console.Write(">");
                t = Console.ReadLine();
                Send(t);
            }

            receiveThread.Abort();
            DisconnectClient(server);
        }

        public void Send(string text)
        {
            writer.Write(text);
        }

        public void Receive()
        {
            while (connected)
            {
                wireConnection.Receive(reader.ReadString());
            }

        }



    }
}
