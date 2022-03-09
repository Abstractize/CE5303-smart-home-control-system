using Services.Implementation;

namespace Services.Contracts
{
    public interface ITimerService
    {
        DateTime TimerStarted { get; }
        Task<WebSocketTimer> CreateTimer(Action action, int waitingTime = 60);
    }
}