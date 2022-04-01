using System;
using Modules.Timers.Scripts;

namespace Modules.Resetters.Scripts
{
    public class TimerResetter : IResetter
    {
        public event Action Activated;
        public string Id { get; init; }
        public string TimerId { get; init; }

        private MemoryTimer _memoryTimer;
        
        public void Init()
        {
            _memoryTimer = new MemoryTimer();
            _memoryTimer.Init(Id);
            _memoryTimer.Over += OnOver;
        }

        private void OnOver()
        {
            Activated?.Invoke();
        }

        public void StopObserving()
        {
            _memoryTimer.Stop();
        }
    }
}