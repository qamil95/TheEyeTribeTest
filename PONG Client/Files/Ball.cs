using System;
using SFML.Graphics;
using SFML.System;

namespace PONG_Client
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

        public void UpdatePosition()
        {
            var factor = Speed;
            Move(Math.Cos(Angle) * factor, Math.Sin(Angle) * factor);
        }

        public void SetPosition(Vector2f position)
        {
            Position = position;
        }

        private void Move(double x, double y)
        {
            Position = Position + new Vector2f((float)x, (float)y);
        }
    }
}
