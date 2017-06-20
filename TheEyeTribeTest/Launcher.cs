using EyeTribe.ClientSdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheEyeTribeTest
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
            checkBoxActivated.Checked =  GazeManager.Instance.Activate(GazeManagerCore.ApiVersion.VERSION_1_0);            
        }

        private void buttonStartApp_Click(object sender, EventArgs e)
        {
            MainApp window = new MainApp();
            GazeManager.Instance.AddGazeListener(window);
            Hide();
            window.ShowDialog();
            Show();
            GazeManager.Instance.RemoveGazeListener(window);
        }

        private void Launcher_FormClosed(object sender, FormClosedEventArgs e)
        {
            GazeManager.Instance.Deactivate();
        }
    }
}
