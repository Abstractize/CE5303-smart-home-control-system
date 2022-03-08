using Business.Managers.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelloHardwareController : ControllerBase
    {
        private readonly IHelloHardwareManager _helloHardwareManager;

        public HelloHardwareController(IHelloHardwareManager helloHardwareManager)
        {
            _helloHardwareManager = helloHardwareManager;
        }

        [HttpGet]
        public Task<String?> Get() 
            => _helloHardwareManager.GetHelloWorldAsync();
        [HttpPost]
        public Task Post() 
            => _helloHardwareManager.PrintHelloWorldAsync();
    }
}
