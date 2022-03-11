using Services.Constants;

namespace Services.Contracts
{
    public interface IHardwareService
    {
        Task<int> SwitchLight(int pin, HardwareStatus value);
        Task<Boolean> IsLightOn(int pin);
        Task<Boolean> IsDoorOpen(int pin);
    }
}