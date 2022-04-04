using System;

namespace Modules.Timers.Scripts
{
    public class TimerDateHelper
    {
        public TimeSpan EndTimeSpan { get; private set; }
        private DateTimeOffset _endDate;
        public bool IsExpired => EndTimeSpan.TotalMilliseconds <= 0;
        
        public void UpdateExpireTimeSpan() => EndTimeSpan = _endDate - DateTimeOffset.Now;
        public void SetEndDate(DateTimeOffset endDate) => _endDate = endDate;
    }
}