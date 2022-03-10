using Models;

namespace Business.Managers.Contracts
{
    public interface IDoorManager
    {
        Task FindAsync(Guid id);
        Task GetAsync();
        Task<Door> GetValue();
    }
}