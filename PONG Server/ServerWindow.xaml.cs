using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace PONG_Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BinaryReader reader;
        private BinaryWriter writer;
        public MainWindow()
        {
            InitializeComponent();

            var listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();
            var client = listener.AcceptTcpClient();
            var stream = client.GetStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }
    }
}
