using System;
using System.Runtime.CompilerServices;
using SFML.Graphics;
using SFML.System;

namespace TheEyeTribeTest.Files
{
    class Ball : CircleShape
    {
        public float Speed { get; }
        public double Angle { get; set; }

        public Ball()
        {
            Angle = 0;
            Speed = 10;

            Radius = 10;
            FillColor = Color.White;
            Origin = new Vector2f(Radius / 2, Radius / 2);
        }

        public void RandomAngle()
        {
            do
            {
                Angle = new Random().Next(360)*2*Math.PI / 360;
            } while (Math.Abs(Math.Cos(Angle)) < 0.7);
        }

        public void UpdateBallPosition()
        {
            var factor = Speed;
            Move(Math.Cos(Angle) * factor, Math.Sin(Angle) * factor);
        }

        private void Move(double x, double y)
        {
            Position = Position + new Vector2f((float)x, (float)y);
        }
    }
}
