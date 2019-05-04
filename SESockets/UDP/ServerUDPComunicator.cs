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

        public UdpClient client;

        public override void Connect(IPAddress ip, int port)
        {
            base.Connect(ip, port);
            client = new UdpClient(port);
            //client.Connect(); //Nao deve ter cliente conectando
            wireConnection.Log("Try connection in IP:" + ip + ":" + port);
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
                    byte[] bytes = client.Receive(ref endPoint);
                    Console.WriteLine($"Received broadcast from {endPoint} :");
                    Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                    client.Send(bytes, bytes.Length);

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //Disconnect();
            }
            
        }
    }
}
