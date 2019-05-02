using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using SESockets.Utils;

namespace SESockets
{
    /// <summary>
    /// Classe abstrata que modela um comunicador que é implementado por um servidor ou cliente.
    /// Tem atributo de ip e porta.
    /// Contêm também networkStream, binary writer e binary reader
    /// Deve-se definir um <code>WireConnection</code> para ter acesso ao Log(), Read() e Write()
    /// </summary>
    public abstract class TCPComunicator
    {

        protected IPAddress ip;
        protected int port = 2108;

        protected NetworkStream stream;
        protected BinaryWriter writer;
        protected BinaryReader reader;

        protected WireConnection wireConnection;

        public virtual void Connect(IPAddress ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public void Connect(string ip)
        {
            Connect(IPUtils.GetIP(ip), port);
        }

        public void Connect(IPAddress ip)
        {
            Connect(ip,port);
        }

        /// <summary>
        /// Define o WireConnection Para um saída personalizada para cada aplicação
        /// </summary>
        /// <param name="wireConnection"></param>
        public void SetWire(WireConnection wireConnection)
        {
            this.wireConnection = wireConnection;
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
        public virtual void DisconnectClient(TcpClient client)
        {
            reader.Close();
            writer.Close();
            stream.Close();
            client.Close();
        }


    }
}
