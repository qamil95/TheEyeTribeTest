using System;
using SFML.System;
using TheEyeTribeTest.Steering_modes;

namespace TheEyeTribeTest.Files
{
    class PaddleGaussian : Paddle
    {
        private const float Speed = 6000;

        public PaddleGaussian(ICursorHeight cursorHeight) : base(cursorHeight)
        {
        }

        public override void UpdatePosition()
        {
            Vector2f gaze;
            var cursorWidth = cursorHeight as ICursorWidth;
            if (cursorWidth != null)
            {
                gaze = new Vector2f(cursorWidth.GetCursorWidth(), cursorHeight.GetCursorHeight());
            }
            else
            {
                gaze = new Vector2f(0, cursorHeight.GetCursorHeight());
            }

            var distance = GetDistance(Position, gaze);
            if (distance < 7) return;

            var toMove = (float)(Speed * GaussianFunction(Math.Abs(distance)));

            if (gaze.Y < Position.Y) //move up
            {
                Position = new Vector2f(Position.X, Position.Y - toMove);
            }
            else //move down
            {
                Position = new Vector2f(Position.X, Position.Y + toMove);
            }
        }

        private static double GaussianFunction(double x)
        {
            const double sigma = 250;
            const double micro = 400;

            var a = Math.Pow((x - micro) / sigma, 2);
            var b = -0.5 * a;
            var c = Math.Pow(Math.E, b);
            var d = sigma * Math.Sqrt(2 * Math.PI);
            return c/d;
        }

        private static double GetDistance(Vector2f a, Vector2f b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }
}