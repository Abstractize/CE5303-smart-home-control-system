using Business.Managers.Contracts;
using System.IO;
using Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;
using Persistence = Data.Models;
using Data.Accessors.Contracts;
using Models.Exceptions;

namespace Business.Managers.Implementation
{
    public class PhotoManager : IPhotoManager
    {
        private readonly ICameraService _cameraService;
        private readonly IPhotoAccessor _photoAccessor;

        public PhotoManager(ICameraService cameraService, IPhotoAccessor photoAccessor)
        {
            _cameraService = cameraService;
            _photoAccessor = photoAccessor;
        }

        public async Task AddAsync()
        {
            Byte[] picData = await _cameraService.TakePicture();
            if (picData == null)
                throw new PictureException();

            await _photoAccessor.AddAsync(new Persistence.Photo
            {
                Id = Guid.NewGuid(),
                FileName = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                Data = picData
            });
        }

        public async Task<FileContentResult> FindAsync(Guid id)
        {
            Persistence.Photo item = await _photoAccessor.FindAsync(i => i.Id == id);
            if (item == null)
                throw new NotFoundException(id);
            return item.LoadTo();
        }

        public async Task<IList<Photo>> GetAsync()
        {
            IList<Persistence.Photo> items = await _photoAccessor.GetAsync();
            return items.Select(item => new Photo().LoadFrom(item)).ToList();
        }
    }
}
