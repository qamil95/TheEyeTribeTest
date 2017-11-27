using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;

namespace PONG_Server
{
    /// <summary>
    /// Interaction logic for ServerWindow.xaml
    /// </summary>
    public partial class ServerWindow : Window
    {
        private Connection masterConnection;
        private Connection slaveConnection;
        public ServerWindow()
        {
            InitializeComponent();

            var listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();
            HandleConnection(listener);
        }

        private async void HandleConnection(TcpListener listener)
        {
            var client = await listener.AcceptTcpClientAsync();
            masterConnection = new Connection(client.GetStream());
            master.Text = $"Master connected at {DateTime.Now}";
            client = await listener.AcceptTcpClientAsync();
            slaveConnection = new Connection(client.GetStream());
            slave.Text = $"Slave connected at {DateTime.Now}";
        }
    }

    public class Connection
    {
        private BinaryReader reader;
        private BinaryWriter writer;

        public Connection(NetworkStream stream)
        {
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }
    }
}
