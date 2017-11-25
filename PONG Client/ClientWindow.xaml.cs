using System.IO;
using System.Net.Sockets;
using System.Windows;

namespace PONG_Client
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
            var client = new TcpClient("localhost", 8888);
            var stream = client.GetStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }
    }
}
