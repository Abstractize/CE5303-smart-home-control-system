using Microsoft.AspNetCore.Mvc;
using Models;

namespace Business.Managers.Contracts
{
    public interface IPhotoManager
    {
        Task<FileContentResult> FindAsync(Guid id);
        Task<IList<Photo>> GetAsync();
        Task AddAsync();
    }
}