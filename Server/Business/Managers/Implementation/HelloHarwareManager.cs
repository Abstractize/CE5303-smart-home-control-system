using Business.Managers.Contracts;
using Services.Contracts;

namespace Business.Managers.Implementation
{
    public class HelloHarwareManager : IHelloHarwareManager
    {
        private readonly IHardwareService _hardewareService;

        public HelloHarwareManager(IHardwareService hardewareService)
        {
            _hardewareService = hardewareService;
        }

        public async Task<String> GetHelloWorldAsync()
            => await _hardewareService.GetHelloAsync();

        public async Task PrintHelloWorldAsync()
            => await _hardewareService.SayHello();
    }
}
