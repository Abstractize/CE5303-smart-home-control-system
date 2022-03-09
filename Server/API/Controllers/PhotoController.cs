using Business.Managers.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoManager _photoManager;

        public PhotoController(IPhotoManager photoManager)
        {
            _photoManager = photoManager;
        }

        [HttpGet]
        public Task<IList<Photo>> Get() 
            => _photoManager.GetAsync();
            
        [HttpGet("{id}")]
        public Task<FileContentResult> Get(Guid id)
            => _photoManager.FindAsync(id);
    }
}
