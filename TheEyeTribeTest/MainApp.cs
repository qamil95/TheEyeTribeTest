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
using EyeTribe.ClientSdk.Data;
using System.Threading;

namespace TheEyeTribeTest
{
    public partial class MainApp : 
        InvokeForm, 
        IGazeListener
    {
        public MainApp()
        {
            InitializeComponent();
        }       

        public void OnGazeUpdate(GazeData gazeData)
        {
            DoInvoke(() => { GazeUpdate(gazeData.SmoothedCoordinates.X, gazeData.SmoothedCoordinates.Y); });            
        }
        private void GazeUpdate(double x, double y)
        {
            double percentX = x / GazeManager.Instance.ScreenResolutionWidth;
            double percentY = y / GazeManager.Instance.ScreenResolutionHeight;
            toolStripStatusLabelX.Text = "X: " + x.ToString() + ' ' + percentX.ToString();
            toolStripStatusLabelY.Text = " | Y: " + y.ToString() + ' ' + percentY.ToString();

            radioButtonPosition.Location = new Point((int)(Size.Width * percentX), (int)(Size.Height * percentY));
            if (percentX < 0.1)
                buttonPosition.Location = new Point(10, (int)(Size.Height * percentY) - (buttonPosition.Size.Height / 2));
        }

        private void MainApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            GazeManager.Instance.RemoveGazeListener(this);
        }
    }
}
