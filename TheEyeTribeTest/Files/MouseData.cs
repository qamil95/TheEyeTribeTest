using SFML.System;
using SFML.Window;

namespace TheEyeTribeTest.Files
{
    class MouseData : ICursorPosition
    {
        public Vector2f GetCursorPosition()
        {
            return new Vector2f(Mouse.GetPosition().X, Mouse.GetPosition().Y);
        }
    }
}
