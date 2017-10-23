using System;
using SFML.System;
using TheEyeTribeTest.Steering_modes;

namespace TheEyeTribeTest.Files
{
    public class PaddleDirectional : Paddle
    {
        private const float Speed = 6;

        public PaddleDirectional(ICursorHeight cursorHeight) : base(cursorHeight)
        {
        }

        public override void UpdatePosition()
        {
            if (!CheckCursorHeight())
                return;
            var difference = cursorHeight.GetCursorHeight() - Position.Y;
            Move(difference);
        }

        private bool CheckCursorHeight()
        {
            if (cursorHeight is KeyboardData)
                return Math.Abs(cursorHeight.GetCursorHeight()) > 0.1;

            return true;
        }

        private void Move(float diff)
        {
            Vector2f offset;
            if (Math.Abs(diff) < Speed)
            {
                offset = new Vector2f(0,0);
            }
            else if (diff<0)
            {
                offset = new Vector2f(0, -Speed);
            }
            else
            {
                offset = new Vector2f(0, Speed);
            }

            Position = Position + offset;
        }
    }
}