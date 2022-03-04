
namespace Services.Contracts
{
    public interface IHardwareService
    {
        Task<String?> GetHelloAsync();
        Task SayHello();
    }
}