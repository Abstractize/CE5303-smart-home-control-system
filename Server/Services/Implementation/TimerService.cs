using Services.Contracts;

namespace Services.Implementation
{
    public class WebSocketTimer
    {
        private readonly Timer _timer;
        private readonly AutoResetEvent _autoResetEvent;
        private readonly Action _action;


        private readonly int _waitingTime;
        internal DateTime TimerStarted { get; set; }

        public WebSocketTimer(Action action, int waitingTime)
        {
            _waitingTime = waitingTime;
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
            TimerStarted = DateTime.Now;
        }

        private void Execute(object stateInfo)
        {
            _action();

            if ((DateTime.Now - TimerStarted).Seconds > _waitingTime)
                _timer.Dispose();
        }
    }
    public class TimerService : ITimerService
    {
        private WebSocketTimer timer;
        public DateTime TimerStarted { get => timer.TimerStarted; }

        public Task<WebSocketTimer> CreateTimer(Action action, int waitingTime = 60)
        {
            this.timer = new WebSocketTimer(action, waitingTime);
            return Task.FromResult(timer);
        }
    }
}
