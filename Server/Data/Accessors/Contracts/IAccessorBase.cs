using Data.Models;

namespace Data.Accessors.Contracts
{
    public interface IAccessorBase<T> where T : Model
    {
        Task AddAsync(T item);
        Task DeleteAsync(Guid id);
        Task<T> FindAsync(Guid id);
        Task<IList<T>> GetAsync();
        Task UpdateAsync(Guid id, T item);
    }
}