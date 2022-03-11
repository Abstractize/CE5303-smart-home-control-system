using Business.Managers.Contracts;
using Microsoft.AspNetCore.SignalR;
using Models;
using System.Runtime.CompilerServices;

namespace API.Hubs.Implementation
{
    public class DoorHub : Hub
    {
        private const int DELAY = 5000;
        private readonly IDoorManager _doorManager;

        public DoorHub(IDoorManager doorManager)
        {
            _doorManager = doorManager;
        }

        public async IAsyncEnumerable<IList<Door>> GetAsync([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            while(true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return await _doorManager.GetAsync();

                await Task.Delay(DELAY, cancellationToken);
            }
        }
    }
}
