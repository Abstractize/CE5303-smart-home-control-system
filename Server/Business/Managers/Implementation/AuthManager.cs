using Business.Managers.Contracts;
using Business.Models;
using Data.Accessors.Contracts;
using Microsoft.AspNetCore.Identity;
using Models;
using Services.Contracts;
using Persistence = Data.Models;

namespace Business.Managers.Implementation
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthService _authService;
        private readonly IUserAccessor _userManager;

        public AuthManager(IAuthService authService, IUserAccessor userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        public async Task<User> LogInAsync(LoginUser userInfo)
        {
            Persistence.User user = await _userManager
                .FindAsync(item => item.Email == userInfo.Email);

            if (user == null)
                throw new Exception($"Email {userInfo.Email} not found");

            if (await _authService.CheckPasswordAsync(user, userInfo.Password))
                return new User().LoadFrom(user);

            throw new Exception($"Incorrect Password");
        }

        public Task LogOutAsync(User userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
