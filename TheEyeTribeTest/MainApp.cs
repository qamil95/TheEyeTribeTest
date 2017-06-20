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

namespace TheEyeTribeTest
{
    public partial class MainApp : Form, IGazeListener
    {
        public MainApp()
        {
            InitializeComponent();
        }       

        public void OnGazeUpdate(GazeData gazeData)
        {
            /*
            double x, y;
            x = this.Size.Width * point.PercentX;
            y = this.Size.Height * point.PercentY;
            toolStripStatusLabelX.Text = "X: " + point.GX.ToString() + ' ' + point.PercentX.ToString();
            toolStripStatusLabelY.Text = " | Y: " + point.GY.ToString() + ' ' + point.PercentY.ToString();

            radioButtonPosition.Location = new System.Drawing.Point((int)x, (int)y);
            if (point.PercentX < 0.1)
                buttonPosition.Location = new System.Drawing.Point(10, (int)y - (buttonPosition.Size.Height / 2));

            ////////
            gX = gazeData.SmoothedCoordinates.X;
            percentX = gX / GazeManager.Instance.ScreenResolutionWidth;
            gY = gazeData.SmoothedCoordinates.Y;
            percentY = gY / GazeManager.Instance.ScreenResolutionHeight;
            */
        }
    }
}
