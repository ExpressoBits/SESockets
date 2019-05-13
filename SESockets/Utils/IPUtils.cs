using System.Net;
using System;
using System.Net.Sockets;

namespace SESockets.Utils
{
    public class IPUtils
    {

        /// <summary>
        /// Get ip from string. returns null if error occurs while parse
        /// </summary>
        /// <param name="iptext"></param>
        /// <returns></returns>
        public static IPAddress GetIP(string iptext)
        {
            if (IPAddress.TryParse(iptext, out IPAddress ip))
            {
                return ip;
            }
            else
            {
                Console.WriteLine("Error on parse ip");
                return null;
            }

        }


        /// <summary>
        /// Get local ip from dns local host. Note: Available only ipv4 
        /// </summary>
        /// <returns> Local IP</returns>
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
