using Business.Managers.Contracts;
using Business.Models;
using Data.Accessors.Contracts;
using Models;
using Models.Exceptions;
using Services.Contracts;
using System.Runtime.CompilerServices;
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
                throw new NotFoundException(id);

            Boolean isOpen = await _hardwareService.IsDoorOpen(item.Pin);

            return new Door().LoadFrom(item, isOpen);
        }

        public async IAsyncEnumerable<Door> FindStreamAsync(Guid id,
            [EnumeratorCancellation] CancellationToken cancellationToken, int delay)
        {
            Persistence.Door item = await _doorAccessor.FindAsync(i => i.Id == id);
            if (item == null)
                throw new NotFoundException(id);

            while (!cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Boolean isOpen = await _hardwareService.IsDoorOpen(item.Pin);
                yield return new Door().LoadFrom(item);

                await Task.Delay(delay, cancellationToken);
            }
        }

        public async Task<IList<Door>> GetAsync()
        {
            IList<Persistence.Door> items = await _doorAccessor.GetAsync();

            return items.Select(async item => new Door()
                .LoadFrom(item, await _hardwareService.IsDoorOpen(item.Pin)))
                .Select(item => item.Result).ToList();
        }

        public async IAsyncEnumerable<IList<Door>> GetStreamAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken, int delay)
        {
            IList<Persistence.Door> items = await _doorAccessor.GetAsync();

            while (true)
            {
                //cancellationToken.ThrowIfCancellationRequested();

                yield return items.Select(async item => new Door()
                    .LoadFrom(item, await _hardwareService.IsDoorOpen(item.Pin)))
                    .Select(item => item.Result).ToList();

                await Task.Delay(delay, cancellationToken);
            }
        }
    }
}
