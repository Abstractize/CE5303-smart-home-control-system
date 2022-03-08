namespace Business.Managers.Contracts
{
    public interface IHelloHardwareManager
    {
        Task<String?> GetHelloWorldAsync();
        Task PrintHelloWorldAsync();
    }
}