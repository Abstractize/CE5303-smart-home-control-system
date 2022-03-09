using static Services.Implementation.HardwareService;

namespace Services.Contracts
{
    public interface IHardwareService
    {
        Task<int> EnablePin(int pin);
        Task<int> DisablePin(int pin);
        Task<int> PinMode(int pin, string mode);
        Task<int> DigitalWrite(int pin, int value);
        Task<int> DigitalRead(int pin);
        Task<Boolean> IsDoorOpen(int pin);
        Task<Boolean> IsLightOn(int pin);
        Task<int> SwitchLight(int pin, HardwareStatus value);
    }
}