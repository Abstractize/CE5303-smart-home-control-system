using OpenCvSharp;

namespace Services.Contracts
{
    public interface ICameraService
    {
        Task<String> GetIP();
        Task<Byte[]> TakePicture();
    }
}