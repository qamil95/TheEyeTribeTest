using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using PONG_Common;
using SFML.System;

namespace PONG_Server
{
    /// <summary>
    /// Interaction logic for ServerWindow.xaml
    /// </summary>
    public partial class ServerWindow : Window
    {
        private Connection masterConnection;
        private Connection slaveConnection;
        private InitialState initMaster;
        private InitialState initSlave;
        private int leftPoints;
        private int rightPoints;
        private Vector2f masterPaddle;
        private Vector2f slavePaddle;
        private Vector2f ballPosition;
        private double ballAngle;
        private string resultMessage;

        public ServerWindow()
        {
            InitializeComponent();
            Task.Run(() => HandleConnection());
        }

        private async void HandleConnection()
        {
            var listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();

            log("Waiting for first client");
            var client = await listener.AcceptTcpClientAsync();
            masterConnection = new Connection(client.GetStream());
            Dispatcher.Invoke(() => master.Text = $"connected {DateTime.Now}");
            masterConnection.SendMessage("Connected as MASTER");

            log("Waiting for second client");
            client = await listener.AcceptTcpClientAsync();
            slaveConnection = new Connection(client.GetStream());
            Dispatcher.Invoke(() => slave.Text = $"connected {DateTime.Now}");
            slaveConnection.SendMessage("Connected as SLAVE");

            listener.Stop();

            InitializeGame();
        }

        private void InitializeGame()
        {
            log("Clients connected - waiting for initial message");
            //read init msg from both clients
            initMaster = JsonConvert.DeserializeObject<InitialState>(masterConnection.ReceiveMessage());
            initSlave = JsonConvert.DeserializeObject<InitialState>(slaveConnection.ReceiveMessage());

            ResetGame();

            resultMessage = "Waiting for connection...";

            //start main loop of application
            while (true)
            {
                var masterState = new GameState
                {
                    BallPosition = ballPosition,
                    ResultMessage = resultMessage,
                    OpponentHeight = slavePaddle.Y,
                    BallAngle = ballAngle,
                };
                var slaveState = new GameState
                {
                    BallPosition = ballPosition,
                    ResultMessage = resultMessage,
                    OpponentHeight = masterPaddle.Y,
                    BallAngle = ballAngle,
                };

                masterConnection.SendMessage(JsonConvert.SerializeObject(masterState));
                slaveConnection.SendMessage(JsonConvert.SerializeObject(slaveState));

                var masterResponse = JsonConvert.DeserializeObject<ClientState>(masterConnection.ReceiveMessage());
                var slaveResponse = JsonConvert.DeserializeObject<ClientState>(slaveConnection.ReceiveMessage());

                if (masterResponse.resetRequested || slaveResponse.resetRequested)
                {
                    ResetGame();
                    continue;
                }

                if (masterResponse.pause || slaveResponse.pause)
                {
                    resultMessage = $"Game paused!{Environment.NewLine}Master requested: {masterResponse.pause}{Environment.NewLine}Slave requested: {slaveResponse.pause}";
                    continue;
                }

                if (masterResponse.rightCollision)
                {
                    leftPoints++;
                    ballPosition = initMaster.StartBallPosition;
                }
                else if (masterResponse.leftCollision)
                {
                    rightPoints++;
                    ballPosition = initMaster.StartBallPosition;
                }
                else
                {
                    ballPosition = masterResponse.newBallPosition;
                }

                resultMessage = $"LEFT {leftPoints} -||- {rightPoints} RIGHT";
                masterPaddle.Y = masterResponse.cursorHeight;
                slavePaddle.Y = slaveResponse.cursorHeight;
                
                if (masterResponse.newBallAngle != null)
                {
                    ballAngle = masterResponse.newBallAngle.Value;
                }
            }
        }
        
        private void ResetGame()
        {
            log("Game reset called");
            leftPoints = 0;
            rightPoints = 0;
            masterPaddle = initMaster.StartPaddlePosition;
            slavePaddle = initSlave.StartPaddlePosition;
            ballPosition = initMaster.StartBallPosition;
            ballAngle = initMaster.StartBallAngle;
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