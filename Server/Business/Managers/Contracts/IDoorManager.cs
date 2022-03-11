using Models;

namespace Business.Managers.Contracts
{
    public interface IDoorManager : IStreamManager<Door>
    {
        Task<Door> FindAsync(Guid id);
        Task<IList<Door>> GetAsync();
    }
}