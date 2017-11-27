using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
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
            master.Text = $"connected {DateTime.Now}";
            client = await listener.AcceptTcpClientAsync();
            slaveConnection = new Connection(client.GetStream());
            slave.Text = $"connected {DateTime.Now}";
            listener.Stop();
        }

        private void ButtonSendMaster_OnClick(object sender, RoutedEventArgs e)
        {
            masterConnection.SendMessage($"Msg to master: {DateTime.Now}");
        }

        private void ButtonSendSlave_OnClick(object sender, RoutedEventArgs e)
        {
            slaveConnection.SendMessage($"Msg to slave: {DateTime.Now}");
        }

        private void ButtonReceiveMaster_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(masterConnection.ReceiveMessage());
        }

        private void ButtonReceiveSlave_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(slaveConnection.ReceiveMessage());
        }
    }

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
