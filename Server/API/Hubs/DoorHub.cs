using Business.Managers.Contracts;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace API.Hubs
{
    public class DoorHub : Hub
    {
        private const int DELAY = 1000;
        private readonly IDoorManager _doorManager;

        public DoorHub(IDoorManager doorManager)
        {
            _doorManager = doorManager;
        }

        public IAsyncEnumerable<Door> Find(CancellationToken cancellationToken, Guid id)
            => _doorManager.FindStreamAsync(id, cancellationToken, DELAY);

        public IAsyncEnumerable<IList<Door>> Get(CancellationToken cancellationToken)
            => _doorManager.GetStreamAsync(cancellationToken, DELAY);
    }
}
