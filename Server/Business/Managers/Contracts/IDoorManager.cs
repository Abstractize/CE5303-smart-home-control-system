using Models;

namespace Business.Managers.Contracts
{
    public interface IDoorManager
    {
        Task<Door> FindAsync(Guid id);
        Task<IList<Door>> GetAsync();
    }
}