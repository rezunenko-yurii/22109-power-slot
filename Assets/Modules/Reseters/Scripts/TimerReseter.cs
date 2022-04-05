using System;
using Modules.Timers.Scripts;
using Zenject;

namespace Modules.Reseters.Scripts
{
    public class TimerReseter : IReseter
    {
        [Inject] private Timers.Scripts.Timers _timers; 
        public event Action Activated;
        public string Id { get; init; }
        public string TimerId { get; init; }

        public MemoryTimer Timer { get; private set; }
        
        public void Init()
        {
            Timer = (MemoryTimer) _timers.GetObject(TimerId);
        }

        public void StartObserving()
        {
            Timer.Over += OnOver;
        }

        private void OnOver()
        {
            Activated?.Invoke();
        }

        public void StopObserving()
        {
            Timer.Stop();
            Timer.Over -= OnOver;
        }

        public bool CanReset()
        {
            return Timer.IsExpired;
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void StartFromBeginning()
        {
            Timer.StartFromBeginning();
        }

        public void Continue()
        {
            Timer.Resume();
        }
    }
}