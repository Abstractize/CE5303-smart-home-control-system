using Business.Managers.Contracts;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using API.Hubs;

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
        public Task Get()
            => _doorManager.GetAsync();

        [HttpGet("{id}")]
        public Task Get(Guid id)
            => _doorManager.FindAsync(id);
    }
}
