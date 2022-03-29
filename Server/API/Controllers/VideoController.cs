using Business.Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoManager _videoManager;

        public VideoController(IVideoManager videoManager)
        {
            _videoManager = videoManager;
        }

        [HttpGet]
        public Task<Video> GetVideo()
            => _videoManager.GetVideoAsync();
    }
}
