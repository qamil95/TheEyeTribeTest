using SFML.System;

namespace PONG_Common
{
    public class ClientState
    {
        public bool leftCollision;
        public bool rightCollision;
        public float cursorHeight;
        public double? newBallAngle;
        public Vector2f newBallPosition;
        public bool pause;
        public bool resetRequested;
    }
}
