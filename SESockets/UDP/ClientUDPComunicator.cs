using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace SESockets.UDP
{
    public class ClientUDPComunicator : UDPComunicator
    {

        public UdpClient client;

        public override void Connect(IPAddress ip, int port)
        {
            base.Connect(ip, port);
            client = new UdpClient();
            client.Connect(ip,port);
            string t = "";
            try
            {

                while (true)
                {
                    Console.Write(">");
                    t = Console.ReadLine();
                    Send(t);
                    string r = Receive();
                    Console.WriteLine("S:"+r);

                }
            }
            catch (SocketException e)
            {
                wireConnection.Log(e.Message);
            }
            
            wireConnection.Log("Message sent to the broadcast address");
        }

        public void Send(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            client.Send(bytes, bytes.Length);
        }

        public string Receive()
        {
            byte[] bytes = client.Receive(ref endPoint);
            return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
        }



    }
}
