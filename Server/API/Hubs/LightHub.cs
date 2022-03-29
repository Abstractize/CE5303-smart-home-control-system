using Business.Managers.Contracts;
using Microsoft.AspNetCore.SignalR;
using Models;
using System.Runtime.CompilerServices;

namespace API.Hubs
{
    public class LightHub : Hub
    {
        private const int DELAY = 1000;
        private readonly ILightManager _lightManager;

        public LightHub(ILightManager lightManager)
        {
            _lightManager = lightManager;
        }

        public IAsyncEnumerable<Light> Find(CancellationToken cancellationToken, Guid id)
            => _lightManager.FindStreamAsync(id, cancellationToken, DELAY);

        public IAsyncEnumerable<IList<Light>> Get(CancellationToken cancellationToken)
            => _lightManager.GetStreamAsync(cancellationToken, DELAY);
    }
}
