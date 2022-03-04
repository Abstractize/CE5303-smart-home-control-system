
using Models;

namespace Business.Managers.Contracts
{
    public interface IAuthManager
    {
        Task<User> LogInAsync(LoginUser userInfo);
        Task LogOutAsync(User userInfo);
    }
}