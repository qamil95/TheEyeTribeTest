using EyeTribe.ClientSdk;
using EyeTribe.ClientSdk.Data;

namespace TheEyeTribeTest
{
    class EyeData : IGazeListener
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public void OnGazeUpdate(GazeData gazeData)
        {
            X = gazeData.SmoothedCoordinates.X;
            Y = gazeData.SmoothedCoordinates.Y;
        }
    }
}
