using Business.Managers.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authorizationManager;

        public AuthController(IAuthManager authorizationManager)
        {
            _authorizationManager = authorizationManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public Task<User> Post(LoginUser userInfo) 
            => _authorizationManager.LogInAsync(userInfo);

        [HttpDelete]
        [AllowAnonymous]
        public Task Delete(User userInfo)
            => _authorizationManager.LogOutAsync(userInfo); 
    }
}
