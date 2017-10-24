using TheEyeTribeTest.Steering_modes;

namespace TheEyeTribeTest.Files
{
    class PaddleGaussian : Paddle
    {
        private const float Speed = 6;

        public PaddleGaussian(ICursorHeight cursorHeight) : base(cursorHeight)
        {
        }

        public override void UpdatePosition()
        {
            
        }
    }
}
