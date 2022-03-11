using Business.Managers.Contracts;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDoorManager _doorManager;

        public DoorController(IDoorManager doorManager)
        {
            _doorManager = doorManager;
        }

        [HttpGet]
        public Task<IList<Door>> Get()
            => _doorManager.GetAsync();

        [HttpGet("{id}")]
        public Task<Door> Get(Guid id)
            => _doorManager.FindAsync(id);
        
    }
}
