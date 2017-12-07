using System;
using System.Net.Sockets;
using System.Windows;
using EyeTribe.ClientSdk;
using PONG_Common;

namespace PONG_Client
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : 
        Window,
        IConnectionStateListener,
        ITrackerStateListener
    {
        private Connection connection;
        public ClientWindow()
        {
            InitializeComponent();
            pongSteeringMode.ItemsSource = Enum.GetValues(typeof(ControlTypes));
        }

        private void connectToTetServer()
        {
            
        }

        private void connectToPongServer()
        {
            var client = new TcpClient("localhost", 8888);
            connection = new Connection(client.GetStream());

            var msg = connection.ReceiveMessage();
        }

        public void OnConnectionStateChanged(bool isConnected)
        {
            serverActivatedStateInfo.Text = isConnected.ToString();
        }

        public void OnTrackerStateChanged(GazeManagerCore.TrackerState trackerState)
        {
            trackerStateInfo.Text = trackerState.ToString();
        }
    }
}
