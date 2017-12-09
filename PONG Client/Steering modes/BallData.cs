namespace PONG_Client.Steering_modes
{
    class BallData : ICursorHeight, ICursorWidth
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

        public float GetCursorWidth()
        {
            return ball.Position.Y;
        }
    }
}
