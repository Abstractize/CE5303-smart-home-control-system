using OpenCvSharp;
using Services.Contracts;

namespace Services.Implementation
{
    public class CameraService : ICameraService
    {
        private readonly VideoCapture _capture;
        private const String IP = "http://195.77.185.114:8081/oneshotimage1?1647511962";
        public CameraService()
        {
            _capture = new VideoCapture(IP);
        }

        public Task<Byte[]> TakePicture()
        {
            var image = new Mat();

            _capture.Read(image);

            if (image.Empty())
                return null;

            return Task.FromResult(image.ToBytes());
        }

        public Task<String> GetIP() => Task.FromResult(IP);
    }
}
