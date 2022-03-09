using Models;

namespace API.Hubs.Contracts
{
    public interface IDoorHub
    {
        Task GetAsync(IList<Door> doors);
        Task FindAsync(Door door);
    }
}