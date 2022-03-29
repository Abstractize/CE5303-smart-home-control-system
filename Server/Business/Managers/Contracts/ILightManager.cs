using Models;

namespace Business.Managers.Contracts
{
    public interface ILightManager : IStreamManager<Light>
    {
        Task<Light> FindAsync(Guid id);
        Task<IList<Light>> GetAsync();
        Task UpdateAsync(Guid id, Light item);
    }
}