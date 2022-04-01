using System;
using UnityEngine;
using Zenject;

namespace Modules.Timers.Scripts
{
    public class Timer
    {
        [Inject] private TickManager _tickManager;
        
        public string Id { get; init; }
        public int Duration { get; set; }

        public event Action Started;
        public event Action Over;
        public event Action<TimeSpan> Counting;
    
        protected DateTimeOffset nextDate;
        protected TimeSpan _expireTimeSpan;

        public void SetTimer(DateTimeOffset nextDate)
        {
            this.nextDate = nextDate;
            _expireTimeSpan = nextDate - DateTimeOffset.Now;
        
            StartCounter();
        }
        
        public virtual void Restart()
        {
            Stop();
            
            this.nextDate = DateTimeOffset.Now.AddSeconds(Duration);
            _expireTimeSpan = nextDate - DateTimeOffset.Now;
            
            StartCounter();
        }
        
        public double SecondsLeft => _expireTimeSpan.TotalSeconds;
        public double HoursLeft => _expireTimeSpan.TotalHours;
        public double MinutesLeft => _expireTimeSpan.TotalMinutes;
        public TimeSpan ExpireTimeSpan => _expireTimeSpan;
        public bool IsExpired => _expireTimeSpan.TotalMilliseconds <= 0;
        private bool _CanCount;

        public bool IsInited { get; protected set; }

        public virtual void Init(string id)
        {
            IsInited = true;
        }
        
        public virtual void Init()
        {
            Init(Id);
        }
    
        protected virtual void OnStarted()
        {
            _CanCount = true;
            Started?.Invoke();
            _tickManager.Add(OnTick);
        }
        protected virtual void OnOver()
        {
            Stop();
            Over?.Invoke();
        }

        protected virtual void OnCounting()
        {
            _expireTimeSpan = nextDate - DateTimeOffset.Now;
            Counting?.Invoke(_expireTimeSpan);
        }
    
        private void StartCounter()
        {
            if (!IsExpired)
            {
                Debug.Log($"Countdown timer started {_expireTimeSpan.TotalSeconds}");
            
                OnStarted();
            }
        }
        
        protected void OnTick()
        {
            if (_CanCount)
            {
                if (IsExpired)
                {
                    OnOver();
                }
                else
                {
                    OnCounting();
                }
            }
        }

        public void Stop()
        {
            _CanCount = false;
            _tickManager.Remove(OnTick);
            
            /*if (_CanCount && !IsExpired)
            {
                _CanCount = false;
            }*/
        }
    }
}