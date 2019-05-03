using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using SESockets.Utils;

namespace SESockets.UDP
{
    public class ServerUDPComunicator : UDPComunicator
    {

        public UdpClient listener;
        public IPEndPoint groupEP;

        public override void Connect(IPAddress ip, int port)
        {
            base.Connect(ip, port);
            listener = new UdpClient(port);
            wireConnection.Log("Try connection in IP:" + ip + ":" + port);
            groupEP = new IPEndPoint(ip, port);
            Run();
        }

        public void Run()
        {
            try
            {
                bool done = false;
                while (!done)
                {

                    wireConnection.Log("Waiting for broadcast");
                    //TcpClient client = listener.AcceptTcpClient();
                    //NewClient(client);

                    byte[] bytes = listener.Receive(ref groupEP);
                    Console.WriteLine($"Received broadcast from {groupEP} :");
                    Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Disconnect();
            }
            
        }
    }
}
