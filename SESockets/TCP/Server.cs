using System.Net;

namespace SESockets.TCP
{
    public class Server
    {

        public int port;
        public IPAddress ip;

        public Server(IPAddress ip,int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public Server(int port)
        {
            this.ip = IPAddress.Any;
            this.port = port;
        }
    }
}
