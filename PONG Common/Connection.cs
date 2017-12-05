using System.IO;
using System.Net.Sockets;

namespace PONG_Common
{
    public class Connection
    {
        private readonly BinaryReader reader;
        private readonly BinaryWriter writer;

        public Connection(NetworkStream stream)
        {
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }

        public void SendMessage(string message)
        {
            writer.Write(message);
        }

        public string ReceiveMessage()
        {
            return reader.ReadString();
        }
    }
}
