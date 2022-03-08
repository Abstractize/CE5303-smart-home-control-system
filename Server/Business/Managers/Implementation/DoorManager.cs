using Business.Managers.Contracts;
using Data.Accessors.Contracts;
using Microsoft.AspNetCore.SignalR;
using Models;
using Services.Contracts;
using Persistence = Data.Models;

namespace Business.Managers.Implementation
{
    public class DoorManager : Hub, IDoorManager
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
            Boolean isDoorOpen = await _hardwareService.IsDoorOpen(item.Pin);
            return new Door
            {
                Id = item.Id,
                RoomName = item.Room.Name,
                IsOpen = isDoorOpen,
            };
        }
        public async Task<IList<Door>> GetAsync()
        {
            IList<Persistence.Door> items = await _doorAccessor.GetAsync();
            return items.Select(async item => new Door
            {
                Id = item.Id,
                RoomName = item.Room.Name,
                IsOpen = await _hardwareService.IsDoorOpen(item.Pin)
            }).Select(item => item.Result).ToList();
        }

    }
}
