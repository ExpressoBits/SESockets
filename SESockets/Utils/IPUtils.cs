using System.Net;
using System;
using System.Net.Sockets;

namespace SESockets.Utils
{
    public class IPUtils
    {

        public static IPAddress GetIP(string iptext)
        {
            return IPAddress.Parse(iptext);
        }


        public static IPAddress GetLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
