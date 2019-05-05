using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SESockets.UDP
{
    public class UdpConnectedClient
    {

        #region Data
        /// <summary>
        /// For Clients, the connection to the server.
        /// For Servers, the connection to a client.
        /// </summary>
        readonly UdpClient connection;
        #endregion

        #region Init
        public UdpConnectedClient(IPEndPoint ip = null)
        {
            if (UDPComunicator.instance.isServer)
            {
                connection = new UdpClient(Globals.port);
            }
            else
            {
                connection = new UdpClient(ip); // Auto-bind port
            }
            connection.BeginReceive(OnReceive, null);
        }

        public void Close()
        {
            connection.Close();
        }
        #endregion

        #region API
        void OnReceive(IAsyncResult ar)
        {
            try
            {
                IPEndPoint ipEndpoint = null;
                byte[] data = connection.EndReceive(ar, ref ipEndpoint);

                UDPComunicator.AddClient(ipEndpoint);


                if (UDPComunicator.instance.isServer)
                {
                    UDPComunicator.BroadcastMessage(data);
                }
            }
            catch (SocketException e)
            {
                // This happens when a client disconnects, as we fail to send to that port.
            }
            connection.BeginReceive(OnReceive, null);
        }

        internal void Send(byte[] bytes, IPEndPoint ipEndpoint)
        {
            connection.Send(bytes, bytes.Length, ipEndpoint);
        }
        #endregion


    }
}
