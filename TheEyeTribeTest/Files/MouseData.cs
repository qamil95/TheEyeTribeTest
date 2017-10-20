using SFML.System;
using SFML.Window;

namespace TheEyeTribeTest.Files
{
    class MouseData : ICursorHeight
    {
        public float GetCursorHeight()
        {
            return Mouse.GetPosition().Y;
        }
    }
}
