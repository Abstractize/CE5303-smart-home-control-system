using Data.Accessors.Contracts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Accessors.Implementation
{
    public class AccessorBase<TModel> : IAccessorBase<TModel> where TModel : Model
    {
        private readonly DbContext _context;
        private readonly DbSet<TModel> _data;

        public AccessorBase(DbSet<TModel> data, DbContext context)
        {
            this._context = context;
            this._data = data;
        }

        public virtual async Task AddAsync(TModel item)
        {
            _data.Add(item);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TModel> FindAsync(Expression<Func<TModel, Boolean>> filter)
        {
            return await _data.AsNoTracking()
                .Where(filter)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<IList<TModel>> GetAsync(Expression<Func<TModel, Boolean>> filter)
        {
            return await _data.AsNoTracking()
                .Where(filter)
                .ToListAsync();
        }

        public virtual async Task UpdateAsync(Guid id, TModel item)
        {
            _data.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}