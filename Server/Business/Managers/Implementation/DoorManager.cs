using API.Hubs;
using API.Hubs.Contracts;
using API.Hubs.Implementation;
using Business.Managers.Contracts;
using Business.Models;
using Data.Accessors.Contracts;
using Microsoft.AspNetCore.SignalR;
using Models;
using Services.Contracts;
using Services.Implementation;
using Persistence = Data.Models;

namespace Business.Managers.Implementation
{
    public class DoorManager : IDoorManager
    {
        private readonly IHardwareService _hardwareService;
        private readonly IDoorAccessor _doorAccessor;
        private readonly IHubContext<DoorHub, IDoorHub> _hubContext;
        private readonly ITimerService _timerService;

        public DoorManager(IHardwareService hardwareService, IDoorAccessor doorAccessor, IHubContext<DoorHub, IDoorHub> hubContext, ITimerService timerService)
        {
            _hardwareService = hardwareService;
            _doorAccessor = doorAccessor;
            _hubContext = hubContext;
            _timerService = timerService;
        }

        public async Task FindAsync(Guid id)
        {
            Persistence.Door item = await _doorAccessor.FindAsync(i => i.Id == id);

            WebSocketTimer timer = await _timerService.CreateTimer(async () =>
            {
                if (item == null)
                    throw new Exception($"{id} not found.");

                Door response = new Door()
                    .LoadFrom(item, await _hardwareService.IsDoorOpen(item.Pin));

                await _hubContext.Clients.All.FindAsync(response);
            });
        }

        public async Task GetAsync()
        {
            IList<Persistence.Door> items = await _doorAccessor.GetAsync();

            WebSocketTimer timer = await _timerService.CreateTimer(async () =>
            {
                var response = items.Select(async item => new Door()
                    .LoadFrom(item, await _hardwareService.IsDoorOpen(item.Pin)))
                    .Select(item => item.Result).ToList();

                await _hubContext.Clients.All.GetAsync(response);
            });
        }
    }
}
