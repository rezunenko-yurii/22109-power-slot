using System;
using UnityEngine;

namespace Modules.Dates
{
    public class LastDateKeeper : DateKeeper
    {
        public int DaysPassed()
        {
            return (int) (DateTime.Now - Date).TotalDays;
        }
        
        public void Update()
        {
            var now = DateTimeOffset.Now.Add(new TimeSpan(0,0,1));
            Debug.Log($"{nameof(LastDateKeeper)} {nameof(Update)} newLastDate={now}");
            
            Date = now;
        }

        protected override string DateCounterPref { get; } = "LastDateKeeper";
    }
}