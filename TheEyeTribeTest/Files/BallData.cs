﻿namespace TheEyeTribeTest.Files
{
    class BallData : ICursorHeight
    {
        private readonly Ball ball;

        public BallData(Ball ball)
        {
            this.ball = ball;
        }

        public float GetCursorHeight()
        {
            return ball.Position.Y;
        }
    }
}
