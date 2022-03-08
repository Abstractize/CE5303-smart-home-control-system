using Data.Models;
using System.Linq.Expressions;

namespace Data.Accessors.Contracts
{
    public interface IAccessorBase<TModel> where TModel : Model
    {
        Task AddAsync(TModel item);
        Task DeleteAsync(Guid id);
        Task<TModel> FindAsync(Expression<Func<TModel, Boolean>> filter);
        Task<IList<TModel>> GetAsync(Expression<Func<TModel, Boolean>> filter);
        Task UpdateAsync(Guid id, TModel item);
    }
}