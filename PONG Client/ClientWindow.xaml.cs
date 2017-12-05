using System.Net;
using System.Net.Sockets;
using System.Windows;
using PONG_Common;

namespace PONG_Client
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private bool connected;
        private Connection connection;
        public ClientWindow()
        {
            InitializeComponent();
            HandleConnection();
        }

        private void HandleConnection()
        {
            var client = new TcpClient("localhost", 8888);
            connection = new Connection(client.GetStream());

            connected = true;
            var msg = connection.ReceiveMessage();
            lastMsg.Text += $"{msg}";
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            connection.SendMessage("ELOMELO");
            lastMsg.Text += $"{connection.ReceiveMessage()}";
        }
    }
}
