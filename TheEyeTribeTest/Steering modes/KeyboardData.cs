using SFML.Window;

namespace TheEyeTribeTest.Steering_modes
{
    class KeyboardData : ICursorHeight
    {
        public float GetCursorHeight()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                return float.NegativeInfinity;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                return float.PositiveInfinity;
            }
            return 0;
        }
    }
}
