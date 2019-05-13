using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace SESockets.TCP
{
    public class TCPComunicator : Comunicator
    {

        #region Data
        public static TCPComunicator instance;

        /// <summary>
        /// For Clients, there is only one and it's the connection to the server.
        /// For Servers, there are many - one per connected client.
        /// </summary>
        List<TCPConnectedClient> clientList = new List<TCPConnectedClient>();

        /// <summary>
        /// Accepts new connections.  Null for clients.
        /// </summary>
        TcpListener listener;
        #endregion


        public TCPComunicator(bool isServer)
        {
            this.isServer = isServer;
        }

        #region Comunicator
        public override void Connect(IPAddress ip)
        {
            instance = this;
            if (ip == null)
            { // Server: start listening for connections
                IPAddress ipserver = IPAddress.Any;
                listener = new TcpListener(localaddr: ipserver, port: Globals.port);
                wireConnection.OnCreateServer(ipserver);
                listener.Start();
                listener.BeginAcceptTcpClient(OnServerConnect, null);
            }
            else
            { // Client: try connecting to the server
                TcpClient client = new TcpClient();
                TCPConnectedClient connectedClient = new TCPConnectedClient(client);
                clientList.Add(connectedClient);
                client.BeginConnect(ip, Globals.port, (ar) => connectedClient.EndConnect(ar), null);
                wireConnection.OnConnectToServer(ip);
            }
        }

        public override void Send(byte[] bytes)
        {
            BroadcastMessage(bytes);

            if (isServer)
            {
                Receive(bytes);
                //messageToDisplay += message + Environment.NewLine;
            }
        }

        public override void Disconnect()
        {
            listener?.Stop();
            for (int i = 0; i < clientList.Count; i++)
            {
                clientList[i].Close();
            }
        }
        #endregion

        #region Async Events
        void OnServerConnect(IAsyncResult ar)
        {
            TcpClient tcpClient = listener.EndAcceptTcpClient(ar);
            clientList.Add(new TCPConnectedClient(tcpClient));
            wireConnection.OnClientConnectToServer(((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address);
            listener.BeginAcceptTcpClient(OnServerConnect, null);
        }
        #endregion

        #region TCP
        public void OnDisconnect(TCPConnectedClient client)
        {
            clientList.Remove(client);
        }

        internal static void BroadcastMessage(byte[] bytes)
        {
            for (int i = 0; i < instance.clientList.Count; i++)
            {
                TCPConnectedClient client = instance.clientList[i];
                client.Send(bytes);
            }
        }
        #endregion


    }
}
