
namespace Services.Contracts
{
    public interface IHardwareService
    {
        Task<int> EnablePin(int pin);
        Task<int> DisablePin(int pin);
        Task<int> PinMode(int pin, string mode);
        Task<int> DigitalWrite(int pin, int value);
        Task<int> DigitalRead(int pin);
    }
}