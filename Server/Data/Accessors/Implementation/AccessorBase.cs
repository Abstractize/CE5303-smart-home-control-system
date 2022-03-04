using Data.Accessors.Contracts;
using Data.Models;

namespace Data.Accessors
{
    public class AccessorBase<TModel> : IAccessorBase<TModel> where TModel : Model
    {
        public virtual async Task AddAsync(TModel item)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TModel> FindAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IList<TModel>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task UpdateAsync(Guid id, TModel item)
        {
            throw new NotImplementedException();
        }
    }
}