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
        private TcpClient client;

        public ClientWindow()
        {
            InitializeComponent();
            pongSteeringMode.ItemsSource = Enum.GetValues(typeof(ControlType));
            pongPaddlePosition.ItemsSource = Enum.GetValues(typeof(PaddlePosition));
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
            if (GazeManager.Instance.IsActivated)
            {
                MessageBox.Show("Already connected");
                return;
            }
            var hostName = tetIP.Text;
            int port;
            if (!int.TryParse(tetPort.Text, out port))
            {
                MessageBox.Show(
                    "Can't parse port to integer - enter valid number",
                    "Error",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error
                    );
                return;
            }

            var activated = GazeManager.Instance.Activate(
                GazeManagerCore.ApiVersion.VERSION_1_0,
                hostName,
                port).ToString();
            var trackerState = GazeManager.Instance.Trackerstate.ToString();
            GazeManager.Instance.AddConnectionStateListener(this);
            GazeManager.Instance.AddTrackerStateListener(this);

            Dispatcher.Invoke(() =>
            {
                serverActivatedStateInfo.Text = activated;
                trackerStateInfo.Text = trackerState;
            });
        }

        private void DisconnectTracker_OnClick(object sender, RoutedEventArgs e)
        {
            if (GazeManager.Instance.IsActivated)
            {
                GazeManager.Instance.Deactivate();
            }
            else
            {
                MessageBox.Show("Already disconnected");
            }
        }

        private void ConnectPongServer_OnClick(object sender, RoutedEventArgs e)
        {
            client = new TcpClient("localhost", 8888);
            connection = new Connection(client.GetStream());

            var msg = connection.ReceiveMessage();
            Dispatcher.Invoke(() =>
            {
                buttonStart.IsEnabled = true;
                buttonConnectPongServer.IsEnabled = false;
                pongConnectionStatus.Text = msg;
            });
        }

        private void StartGame_OnClick(object sender, RoutedEventArgs e)
        {
            buttonStart.IsEnabled = false;
            var game = new Game((ControlType)pongSteeringMode.SelectionBoxItem, fullScreenGameWindow.IsChecked, connection);
            game.Run((PaddlePosition)pongPaddlePosition.SelectionBoxItem);

            client.Close();
        }
    }
}