using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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

        public void OnConnectionStateChanged(bool isConnected)
        {
            Dispatcher.Invoke(() => serverActivatedStateInfo.Text = isConnected.ToString());
        }

        public void OnTrackerStateChanged(GazeManagerCore.TrackerState trackerState)
        {
            Dispatcher.Invoke(() => trackerStateInfo.Text = trackerState.ToString());
        }

        private void ConnectTracker_OnClick(object sender, RoutedEventArgs e)
        {
            var activated = GazeManager.Instance.Activate(GazeManagerCore.ApiVersion.VERSION_1_0).ToString();
            var trackerState = GazeManager.Instance.Trackerstate.ToString();
            GazeManager.Instance.AddConnectionStateListener(this);
            GazeManager.Instance.AddTrackerStateListener(this);

            Dispatcher.Invoke(() =>
            {
                serverActivatedStateInfo.Text = activated;
                trackerStateInfo.Text = trackerState;
            });
        }

        private void ConnectPongServer_OnClick(object sender, RoutedEventArgs e)
        {
            var client = new TcpClient("localhost", 8888);
            connection = new Connection(client.GetStream());

            var msg = connection.ReceiveMessage();
        }

        private void StartGame_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}