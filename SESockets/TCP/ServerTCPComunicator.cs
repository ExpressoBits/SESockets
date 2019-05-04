﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using SESockets.Utils;

namespace SESockets.TCP
{
    public class ServerTCPComunicator : TCPComunicator
    {

        //TCP para ouvir clientes
        private TcpListener listener;


        public override void Connect(IPAddress ip, int port)
        {
            base.Connect(ip, port);
            listener = new TcpListener(ip, port);
            wireConnection.Log("Try connection in IP:" + ip + ":" + port);
            listener.Start();
            wireConnection.Log("Start server:" + ip + ":" + port);
            connected = true;
            Run();
        }

        

        public void Run()
        {
            bool done = false;
            while (!done)
            {
                wireConnection.Log("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();
                NewClient(client);

            }
            Disconnect();
        }

        public void Disconnect()
        {
            listener.Stop();
        }

        public void NewClient(TcpClient client)
        {
            string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            //TODO tratamente de clientes
            wireConnection.Log("Connection accepted with IP " + clientIP);

            Init(client.GetStream());

            while (connected)
            {
                string t = reader.ReadString();
                if (t == "END") return;
                wireConnection.Receive(t);
                writer.Write(t);
            }
        }





    }
}

