using System.Net.Http.Headers;
using Services.Contracts;

namespace Services.Implementation
{
    public class CameraService : ICameraService
    {
        private const String IP = "http://195.77.185.114:8081/oneshotimage1?1647511962";
        public CameraService()
        {

        }

        public async Task<Byte[]> TakePicture()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(IP);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("image/jpeg")
            );

            var image = await client.GetByteArrayAsync("");

            return image;
        }

        public Task<String> GetIP() => Task.FromResult(IP);
    }
}
