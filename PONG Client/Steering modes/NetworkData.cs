using System;

namespace PONG_Client.Steering_modes
{
    class NetworkData : ICursorHeight
    {
        private float cursorHeight;
        public float GetCursorHeight()
        {
            return cursorHeight;
        }

        public void SetCursorHeight(float height)
        {
            cursorHeight = height;
        }
    }
}
