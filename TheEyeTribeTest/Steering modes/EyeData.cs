using EyeTribe.ClientSdk;
using EyeTribe.ClientSdk.Data;

namespace TheEyeTribeTest.Steering_modes
{
    class EyeData : IGazeListener, ICursorHeight
    {
        private float x;
        private float y;

        public EyeData()
        {
            GazeManager.Instance.AddGazeListener(this);
        }

        public void OnGazeUpdate(GazeData gazeData)
        {
            x = gazeData.SmoothedCoordinates.X;
            y = gazeData.SmoothedCoordinates.Y;
        }

        public float GetCursorHeight()
        {
            return y;
        }
    }
}