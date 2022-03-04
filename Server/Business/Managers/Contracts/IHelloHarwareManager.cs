
namespace Business.Managers.Contracts
{
    public interface IHelloHarwareManager
    {
        Task<string> GetHelloWorldAsync();
        Task PrintHelloWorldAsync();
    }
}