using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace SESockets.UDP
{
    public class ClientUDPComunicator : UDPComunicator
    {

        public UdpClient listener;

        public override void Connect(IPAddress ip, int port)
        {
            base.Connect(ip, port);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);


            byte[] sendbuf = Encoding.ASCII.GetBytes("Teste");

            s.SendTo(sendbuf, endPoint);

            Console.WriteLine("Message sent to the broadcast address");
        }



    }
}
