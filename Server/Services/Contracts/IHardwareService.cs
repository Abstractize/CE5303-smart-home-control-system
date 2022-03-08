
namespace Services.Contracts
{
    public interface IHardwareService
    {
        Task<String?> GetHelloAsync();
        Task SayHello();
        Task<Boolean> IsDoorOpen(int pin);
    }
}