using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SESockets.TCP
{
    public class TcpConnectedClient
    {

        #region Data
        /// <summary>
        /// For Clients, the connection to the server.
        /// For Servers, the connection to a client.
        /// </summary>
        readonly TcpClient connection;

        readonly byte[] readBuffer = new byte[5000];

        NetworkStream stream
        {
            get
            {
                return connection.GetStream();
            }
        }
        #endregion

        #region Init
        public TcpConnectedClient(TcpClient tcpClient)
        {
            this.connection = tcpClient;
            this.connection.NoDelay = true; // Disable Nagle's cache algorithm
            if (TCPComunicator.instance.isServer)
            { // Client is awaiting EndConnect
                stream.BeginRead(readBuffer, 0, readBuffer.Length, OnRead, null);
            }
        }

        internal void Close()
        {
            connection.Close();
        }
        #endregion

        #region Async Events
        void OnRead(IAsyncResult ar)
        {
            int length = stream.EndRead(ar);
            if(length <= 0)
            {//Connection close
                TCPComunicator.instance.OnDisconnect(this);
                return;
            }

            string newMessage = System.Text.Encoding.UTF8.GetString(readBuffer, 0, length);
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(newMessage);
            //TCPChat.messageToDisplay += newMessage + Environment.NewLine;
            TCPComunicator.instance.Receive(bytes);

            if (TCPComunicator.instance.isServer)
            {
                TCPComunicator.BroadcastMessage(bytes);
            }

            stream.BeginRead(readBuffer, 0, readBuffer.Length, OnRead, null);
        }

        internal void EndConnect(IAsyncResult ar)
        {
            connection.EndConnect(ar);

            stream.BeginRead(readBuffer, 0, readBuffer.Length, OnRead, null);
        }
        #endregion

        #region API
        internal void Send(byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }
        #endregion

    }
}
