using System.Runtime.CompilerServices;
using EyeTribe.ClientSdk;
using EyeTribe.ClientSdk.Data;
using SFML.System;
using SFML.Window;
using TheEyeTribeTest.Files;

namespace TheEyeTribeTest
{
    class EyeData : IGazeListener, ICursorPosition
    {
        private float x;
        private float y;

        private bool mouseEmulation;

        public void OnGazeUpdate(GazeData gazeData)
        {
            x = gazeData.SmoothedCoordinates.X;
            y = gazeData.SmoothedCoordinates.Y;
        }
        
        public Vector2f GetCursorPosition()
        {
            return new Vector2f(x, y);
        }
    }
}
