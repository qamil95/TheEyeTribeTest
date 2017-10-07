using System;
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
            Speed = 400;

            Radius = 10;
            FillColor = Color.White;
            Origin = new Vector2f(Radius / 2, Radius / 2);
        }

        public void RandomAngle()
        {
            do
            {
                Angle = new Random(360).Next()*2*Math.PI;
            } while (Math.Abs(Math.Cos(Angle)) < 0.7);
        }
    }
}
