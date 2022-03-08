using Business.Managers.Contracts;
using System.IO;
using Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;
using Persistence = Data.Models;
using Data.Accessors.Contracts;

namespace Business.Managers.Implementation
{
    public class PhotoManager : IPhotoManager
    {
        private readonly IPhotoAccessor _photoAccessor;

        public PhotoManager(IPhotoAccessor photoAccessor)
        {
            _photoAccessor = photoAccessor;
        }

        public async Task<FileContentResult> FindAsync(Guid id)
        {
            Persistence.Photo item = await _photoAccessor.FindAsync(i => i.Id == id);
            if (item == null)
                throw new Exception($"{id} not found.");
            return item.LoadTo();
        }

        public async Task<IList<Photo>> GetAsync()
        {
            IList<Persistence.Photo> items = await _photoAccessor.GetAsync();
            return items.Select(item => new Photo().LoadFrom(item)).ToList();
        }
    }
}
