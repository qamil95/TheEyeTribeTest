using EyeTribe.ClientSdk;
using EyeTribe.ClientSdk.Data;

namespace PONG_Client.Steering_modes
{
    class EyeData : IGazeListener, ICursorHeight, ICursorWidth
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

        public float GetCursorWidth()
        {
            return x;
        }

        public float GetCursorHeight()
        {
            return y;
        }
    }
}