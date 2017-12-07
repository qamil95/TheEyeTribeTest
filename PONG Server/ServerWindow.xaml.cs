using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using PONG_Common;

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
            Task.Run(()=>HandleConnection());
        }

        private async void HandleConnection()
        {
            var listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();

            log("Waiting for first client");
            var client = await listener.AcceptTcpClientAsync();
            masterConnection = new Connection(client.GetStream());
            Dispatcher.Invoke(()=>master.Text = $"connected {DateTime.Now}");
            masterConnection.SendMessage("Connected as MASTER");

            log("Waiting for second client");
            client = await listener.AcceptTcpClientAsync();
            slaveConnection = new Connection(client.GetStream());
            Dispatcher.Invoke(()=>slave.Text = $"connected {DateTime.Now}");
            slaveConnection.SendMessage("Connected as SLAVE");

            listener.Stop();

            InitializeGame();
        }

        private void InitializeGame()
        {
            log("Clients connected - waiting for initial message");
            //read init msg from both clients
            log("init master: " + masterConnection.ReceiveMessage());
            log("init slave: " + slaveConnection.ReceiveMessage());

            //start main loop of application
            while (true)
            {
                masterConnection.SendMessage("Data for master");
                slaveConnection.SendMessage("Data for slave");
                var masterResponse = masterConnection.ReceiveMessage();
                var slaveResponse = slaveConnection.ReceiveMessage();

                //parse response, evaluate
                log($"MASTER {masterResponse}, SLAVE {slaveResponse}");
            }
        }

        private void log(string text)
        {
            Dispatcher.Invoke(() =>
            {
                logTextBlock.Text += text + Environment.NewLine;
                scrollViewer.ScrollToBottom();
            });
        }
    }
}