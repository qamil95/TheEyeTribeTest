using SFML.Graphics;
using SFML.System;

namespace TheEyeTribeTest.Files
{
    class Paddle : RectangleShape
    {
        private float speed;

        public Paddle()
        {
            Size = new Vector2f(25, 100);
            FillColor = Color.White;
            Origin = Size / 2;
            speed = 400;
        }
    }
}
