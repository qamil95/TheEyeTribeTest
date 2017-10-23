using EyeTribe.ClientSdk;
using SFML.Graphics;
using SFML.System;
using TheEyeTribeTest.Steering_modes;

namespace TheEyeTribeTest.Files
{
    public class Paddle : RectangleShape
    {
        protected readonly ICursorHeight cursorHeight;

        public Paddle(ICursorHeight cursorHeight)
        {
            Size = new Vector2f(25, 100);
            FillColor = Color.White;
            Origin = Size / 2;
            this.cursorHeight = cursorHeight;
        }

        public virtual void UpdatePosition()
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
