using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SESockets.UDP
{
    public class UDPComunicator : Comunicator
    {

        #region Data
        public static UDPComunicator instance;
        /// <summary>
        /// For Clients, there is only one and it's the connection to the server.
        /// For Servers, there are many - one per connected client.
        /// </summary>
        List<IPEndPoint> clientList = new List<IPEndPoint>();

        UdpConnectedClient connection;
        #endregion

        public UDPComunicator(bool isServer)
        {
            this.isServer = isServer;
        }

        #region Comunicator
        public override void Connect(IPAddress ip)
        {
            instance = this;
            if (ip == null)
            {
                connection = new UdpConnectedClient();
            }
            else
            {
                IPEndPoint ipend = new IPEndPoint(ip, Globals.port);
                connection = new UdpConnectedClient(ipend);
                AddClient(ipend);
            }
        }

        public override void Send(byte[] bytes)
        {
            if (isServer)
            {
                Receive(bytes);
            }

            BroadcastMessage(bytes);
        }

        public override void Disconnect()
        {
            connection.Close();
        }
        #endregion

        #region UDP
        internal static void BroadcastMessage(byte[] bytes)
        {
            foreach (var ip in instance.clientList)
            {
                instance.connection.Send(bytes, ip);
            }
        }

        internal static void AddClient(IPEndPoint ipEndpoint)
        {
            if (instance.clientList.Contains(ipEndpoint) == false)
            { // If it's a new client, add to the client list
                instance.wireConnection.Log($"Connect to {ipEndpoint}");
                instance.clientList.Add(ipEndpoint);
            }
        }

        /// <summary>
        /// TODO: We need to add timestamps to timeout and remove clients from the list.
        /// </summary>
        internal static void RemoveClient(
        IPEndPoint ipEndpoint)
        {
            instance.clientList.Remove(ipEndpoint);
        }

        #endregion

    }
}
