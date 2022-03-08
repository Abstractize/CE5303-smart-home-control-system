using Business.Managers.Contracts;
using Services.Contracts;

namespace Business.Managers.Implementation
{
    public class HelloHardwareManager : IHelloHardwareManager
    {
        private readonly IHardwareService _hardwareService;

        public HelloHardwareManager(IHardwareService hardwareService)
        {
            _hardwareService = hardwareService;
        }

        public async Task<String?> GetHelloWorldAsync()
            => await _hardwareService.GetHelloAsync();

        public async Task PrintHelloWorldAsync()
            => await _hardwareService.SayHello();
    }
}
