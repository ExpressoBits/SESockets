using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace SESockets.TCP
{
    public abstract class TCPComunicator : Comunicator
    {

        protected BinaryWriter writer;
        protected BinaryReader reader;

        protected bool connected;


        protected Thread receiveThread;

        /// <summary>
        /// Desconecta o cliente
        /// </summary>
        /// <param name="client"></param>
        public virtual void DisconnectClient(TcpClient client)
        {
            Disconnect();
            client.Close();
        }

        /// <summary>
        /// Inicializa o stream criando o BinaryWriter e o BinaryReader
        /// </summary>
        /// <param name="stream"></param>
        public void Init(NetworkStream stream)
        {
            this.stream = stream;
            writer = new BinaryWriter(stream);
            reader = new BinaryReader(stream);
        }

        /// <summary>
        /// Método que disconecta um cliente
        /// </summary>
        /// <param name="client"></param>
        public virtual void Disconnect()
        {
            reader.Close();
            writer.Close();
            stream.Close();
            connected = false;
        }

    }
}
