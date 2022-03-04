using Business.Managers.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelloHardwareController : ControllerBase
    {
        private readonly IHelloHarwareManager _helloHarwareManager;

        public HelloHardwareController(IHelloHarwareManager helloHarwareManager)
        {
            _helloHarwareManager = helloHarwareManager;
        }

        [HttpGet]
        public Task<String> Get() 
            => _helloHarwareManager.GetHelloWorldAsync();
        [HttpPost]
        public Task Post() 
            => _helloHarwareManager.PrintHelloWorldAsync();
    }
}
