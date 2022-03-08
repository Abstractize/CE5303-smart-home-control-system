using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("id")]
        public Task<User> Get(Guid id) 
            => throw new NotImplementedException();
    }
}
