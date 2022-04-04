using System;
using Zenject;

namespace Modules.Timers.Scripts
{
    public class Timer
    {
        [Inject] private TickManager _tickManager;
        
        public event Action Started;
        public event Action Over;
        public event Action<int> Counting;
        
        private int _secondsLeft = 0;
        public bool HasTime => _secondsLeft > 0;

        public virtual void Init() { }

        public void Restart(int seconds)
        {
            Stop();
            Start(seconds);
        }
        
        public virtual void Stop()
        {
            _tickManager.Remove(OnTick);
        }
        protected virtual void Start(int seconds)
        {
            if (HasTime)
            {
                throw new Exception("Timer already started");
            }
            
            _secondsLeft = seconds;

            Started?.Invoke();
            _tickManager.Add(OnTick);
        }
        
        private void OnTick()
        {
            if (!HasTime)
            {
                OnOver();
            }
            else
            {
                OnCounting();
            }
        }

        private void OnOver()
        {
            Stop();
            Over?.Invoke();
        }

        private void OnCounting()
        {
            _secondsLeft--;
            Counting?.Invoke(_secondsLeft);
        }
    }
}