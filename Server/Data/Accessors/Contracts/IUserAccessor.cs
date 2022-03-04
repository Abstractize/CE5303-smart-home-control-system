using Data.Models;
using System.Linq.Expressions;

namespace Data.Accessors.Contracts
{
    public interface IUserAccessor
    {
        Task<User> FindAsync(Expression<Func<User, Boolean>> filter);
    }
}