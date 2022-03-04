using Data.Accessors.Contracts;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Accessors.Implementation
{
    public class UserAccessor : IUserAccessor
    {
        private readonly HomeContext _context;

        public UserAccessor(HomeContext context)
        {
            _context = context;
        }

        public async Task<User> FindAsync(Expression<Func<User, Boolean>> filter)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(filter)
                .FirstOrDefaultAsync();
        }
    }
}
