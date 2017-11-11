using SFML.Window;

namespace TheEyeTribeTest.Steering_modes
{
    class MouseData : ICursorHeight, ICursorWidth
    {
        public float GetCursorHeight()
        {
            return Mouse.GetPosition().Y;
        }

        public float GetCursorWidth()
        {
            return Mouse.GetPosition().Y;
        }
    }
}
