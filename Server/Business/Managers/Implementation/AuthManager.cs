using Business.Managers.Contracts;
using Business.Models;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.Exceptions;
using Services.Contracts;
using Persistence = Data.Models;

namespace Business.Managers.Implementation
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthService _authService;
        public AuthManager(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<User> LogInAsync(LoginUser userInfo)
        {
            Persistence.User user = await _authService
                .FindByEmailAsync(userInfo.Email);

            if (user == null)
                throw new NotFoundException<string>(userInfo.Email, "User with email '{0}' not found");

            SignInResult result = await _authService
                .CheckPasswordSignInAsync(user, userInfo.Password);

            if (result.Succeeded)
                return new User().LoadFrom(user);

            throw new IncorrectPasswordException(userInfo.Email);
        }

        public async Task LogOutAsync(User user)
        {
            await _authService.SignOutAsync();
        }
    }
}
