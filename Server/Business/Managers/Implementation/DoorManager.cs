using Business.Managers.Contracts;
using Business.Models;
using Data.Accessors.Contracts;
using Models;
using Services.Contracts;
using Persistence = Data.Models;

namespace Business.Managers.Implementation
{
    public class DoorManager : IDoorManager
    {
        private readonly IHardwareService _hardwareService;
        private readonly IDoorAccessor _doorAccessor;

        public DoorManager(IHardwareService hardwareService, IDoorAccessor doorAccessor)
        {
            _hardwareService = hardwareService;
            _doorAccessor = doorAccessor;
        }

        public async Task<Door> FindAsync(Guid id)
        {
            Persistence.Door item = await _doorAccessor.FindAsync(i => i.Id == id);

            if (item == null)
                throw new Exception($"{id} not found.");

            //Boolean isOpen = await _hardwareService.IsDoorOpen(item.Pin);

            return new Door().LoadFrom(item, true);
        }

        public async Task<IList<Door>> GetAsync()
        {
            IList<Persistence.Door> items = await _doorAccessor.GetAsync();

            return items.Select(async item => new Door()
                //.LoadFrom(item, await _hardwareService.IsDoorOpen(item.Pin)))
                .LoadFrom(item, true))
                .Select(item => item.Result).ToList();
        }
    }
}
