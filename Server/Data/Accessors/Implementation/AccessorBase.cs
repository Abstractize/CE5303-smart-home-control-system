using Data.Accessors.Contracts;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Accessors.Implementation
{
    public class AccessorBase<TModel> : IAccessorBase<TModel> where TModel : Model
    {
        protected readonly HomeContext _context;
        protected readonly DbSet<TModel> _data;

        public AccessorBase(DbSet<TModel> data, HomeContext context)
        {
            this._context = context;
            this._data = data;
        }

        public virtual async Task AddAsync(TModel item)
        {
            _data.Add(item);
            await _context.SaveChangesAsync();
        }

        public virtual Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TModel> FindAsync(Expression<Func<TModel, Boolean>> filter)
        {
            return await _data.AsNoTracking()
                .Where(filter)
                .FirstOrDefaultAsync();
        }
        public virtual async Task<IList<TModel>> GetAsync()
        {
            return await _data.AsNoTracking()
                .ToListAsync();
        }
        public virtual async Task<IList<TModel>> GetAsync(Expression<Func<TModel, Boolean>> filter = null)
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