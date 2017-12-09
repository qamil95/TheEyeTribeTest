using System;
using SFML.Graphics;
using SFML.System;

namespace PONG_Client
{
    class CentralText : Text
    {
        private Vector2f windowSize;

        public CentralText(Vector2u windowSize)
        {
            this.windowSize = new Vector2f(windowSize.X, windowSize.Y);
        }

        public void SetText(string text)
        {
            DisplayedString = text;
            Origin = new Vector2f(GetLocalBounds().Width / 2, GetLocalBounds().Height / 2);
            Position = new Vector2f(windowSize.X / 2, windowSize.Y/2);
        }

        public void AppendText(string text)
        {
            SetText(DisplayedString + Environment.NewLine + text);
        }
    }
}
