using SFML.Graphics;
using SFML.Window;

namespace PONG_Client.Steering_modes
{
    class MouseData : ICursorHeight, ICursorWidth
    {
        private readonly Window win;

        public MouseData(Window app)
        {
            win = app;
        }

        public float GetCursorHeight()
        {
            return Mouse.GetPosition(win).Y;
        }

        public float GetCursorWidth()
        {
            return Mouse.GetPosition(win).X;
        }
    }
}
