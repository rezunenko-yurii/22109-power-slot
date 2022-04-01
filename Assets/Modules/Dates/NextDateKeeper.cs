using System;

namespace Modules.Dates
{
    public class NextDateKeeper : DateKeeper
    {
        public int DaysLeft()
        {
            return (int) (Date - DateTime.Now).TotalDays;
        }
        
        public int HoursLeft()
        {
            return (int) (Date - DateTime.Now).TotalHours;
        }
        
        public int SecondsLeft()
        {
            return (int) (Date - DateTime.Now).TotalSeconds;
        }
        
        public int MillisecondsSecondsLeft()
        {
            return (int) (Date - DateTime.Now).TotalMilliseconds;
        }
        
        public void AddDays(int amount)
        {
            Date = Date.AddDays(amount);
        }
        
        public void AddHours(int amount)
        {
            Date = Date.AddHours(amount);
        }
        
        public void AddHoursFromNow(int amount)
        {
            Date = DateTimeOffset.Now.AddHours(amount);
        }
        
        public void AddMinutesFromNow(int amount)
        {
            Date = DateTimeOffset.Now.AddMinutes(amount);
        }
        
        public void AddSecondsFromNow(int amount)
        {
            Date = DateTimeOffset.Now.AddSeconds(amount);
        }

        public void Reset()
        {
            Date = DateTimeOffset.Now;
        }

        public bool IsExpired()
        {
            return Date.Offset.TotalMilliseconds <= 0;
        }

        protected override string DateCounterPref { get; } = "NextDateKeeper";
    }
}