using EyeTribe.ClientSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeTribe.ClientSdk.Data;

namespace TheEyeTribeTest
{
    class Point : IGazeListener
    {
        double gX, gY, percentX, percentY;        
        public Point()
        {
            // Connect client 
            GazeManager.Instance.Activate(GazeManager.ApiVersion.VERSION_1_0);

            // Register this class for events 
            GazeManager.Instance.AddGazeListener(this);            
        }

        public double GX
        {
            get
            {
                return gX;
            }

            set
            {
                gX = value;
            }
        }

        public double GY
        {
            get
            {
                return gY;
            }

            set
            {
                gY = value;
            }
        }

        public double PercentX
        {
            get
            {
                return percentX;
            }

            set
            {
                percentX = value;
            }
        }

        public double PercentY
        {
            get
            {
                return percentY;
            }

            set
            {
                percentY = value;
            }
        }

        public void OnGazeUpdate(GazeData gazeData)
        {
            gX = gazeData.SmoothedCoordinates.X;
            percentX = gX / GazeManager.Instance.ScreenResolutionWidth;
            gY = gazeData.SmoothedCoordinates.Y;
            percentY = gY / GazeManager.Instance.ScreenResolutionHeight;
        }

        public void Disconnect()
        {
            // Disconnect client
            GazeManager.Instance.Deactivate();
        }
    }
}
