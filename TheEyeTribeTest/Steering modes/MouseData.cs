using SFML.Window;

namespace TheEyeTribeTest.Steering_modes
{
    class MouseData : ICursorHeight
    {
        public float GetCursorHeight()
        {
            return Mouse.GetPosition().Y;
        }
    }
}
