using Business.Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;

namespace Business.Managers.Implementation
{
    public class VideoManager : IVideoManager
    {
        private readonly ICameraService _cameraService;

        public VideoManager(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public async Task<Video> GetVideoAsync()
        {
            return new Video
            {
                Url = await _cameraService.GetIP()
            };
        }
    }
}
