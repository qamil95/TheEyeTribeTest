using EyeTribe.ClientSdk;
using SFML.Graphics;
using SFML.System;

namespace TheEyeTribeTest.Files
{
    class Paddle : RectangleShape
    {
        private readonly ICursorHeight cursorHeight;

        public Paddle(ICursorHeight cursorHeight)
        {
            Size = new Vector2f(25, 100);
            FillColor = Color.White;
            Origin = Size / 2;
            this.cursorHeight = cursorHeight;
        }

        public void UpdatePosition()
        {
            Position = new Vector2f(Position.X, cursorHeight.GetCursorHeight());
        }

        public void RemoveGazeListener()
        {
            var cursor = cursorHeight as EyeData;
            if (cursor != null)
            {
                GazeManager.Instance.RemoveGazeListener(cursor);
            }
        }
    }
}
