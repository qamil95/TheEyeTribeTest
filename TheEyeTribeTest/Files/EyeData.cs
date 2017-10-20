using System.Runtime.CompilerServices;
using EyeTribe.ClientSdk;
using EyeTribe.ClientSdk.Data;
using SFML.System;
using SFML.Window;
using TheEyeTribeTest.Files;

namespace TheEyeTribeTest
{
    class EyeData : IGazeListener, ICursorHeight
    {
        private float x;
        private float y;
        
        public void OnGazeUpdate(GazeData gazeData)
        {
            x = gazeData.SmoothedCoordinates.X;
            y = gazeData.SmoothedCoordinates.Y;
        }
        
        public float GetCursorHeight()
        {
            return y;
        }
    }
}
