using System;
using SFML.System;
using TheEyeTribeTest.Steering_modes;

namespace TheEyeTribeTest.Files
{
    class PaddleGaussian : Paddle
    {
        private const float Speed = 7000;

        public PaddleGaussian(ICursorHeight cursorHeight) : base(cursorHeight)
        {
        }

        public override void UpdatePosition()
        {
            var gazeHeight = cursorHeight.GetCursorHeight();
            var paddleHeight = Position.Y;
            var distance = paddleHeight - gazeHeight;

            var toMove = (float)(Speed*GaussianFunction(Math.Abs(distance)));

            if (distance > 0) //move up
            {
                Position = new Vector2f(Position.X, Position.Y - toMove);
            }
            else //move down
            {
                Position = new Vector2f(Position.X, Position.Y + toMove);
            }
        }

        private double GaussianFunction(double x)
        {
            double sigma = 250;
            double micro = 400;

            var a = Math.Pow((x - micro) / sigma, 2);
            var b = -0.5 * a;
            var c = Math.Pow(Math.E, b);
            var d = sigma * Math.Sqrt(2 * Math.PI);
            return c/d;
        }
    }
}
