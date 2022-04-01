using System;
using Modules.Dates;
using UnityEngine;
using Zenject;

namespace DailyReward
{
    public class EveryDayCounter
    {
        [Inject] private DateKeepers _dateKeepers;
        public Action Updated;
        private const string EveryDayCounterPref = "EveryDayCounter";

        public string ID { get; private set; }
        public string DaysId { get; private set; }

        private LastDateKeeper _lastDateKeeper;

        public int MaxDays { get; private set; }
        public int MaxDaysGap { get; private set; }
        
        private int _days;
        public int CurrentDay
        {
            get
            {
                if (_days != 0)
                {
                    var daysPassed = _lastDateKeeper.DaysPassed();
                    if (daysPassed > MaxDaysGap)
                    {
                        Reset();
                    }
                }
                
                return _days;
            }
            private set
            {
                _days = value;
                PlayerPrefs.SetInt(DaysId, _days);
                Updated?.Invoke();
            }
        }

        private int GetNextDay()
        {
            int nextDay = _days + 1;
            if (nextDay >= MaxDays)
            {
                return 0;
            }
            else
            {
                return nextDay;
            }
        }
        
        /*public EveryDayCounter(Enum id, int maxDays, int maxDaysGap) : this(id.ToString(), maxDays, maxDaysGap) { }
        
        public EveryDayCounter(string id, int maxDays, int maxDaysGap)
        {
            Debug.Log($"{nameof(EveryDayCounter)} Constructor // id={id} maxDays={maxDays}");
            ID = id;
            MaxDays = maxDays;
            MaxDaysGap = maxDaysGap;
        
            DaysId = $"{EveryDayCounterPref} {ID}";

            Load();
        }*/

        public void Init(string id, int maxDays, int maxDaysGap)
        {
            ID = id;
            MaxDays = maxDays;
            MaxDaysGap = maxDaysGap;
        
            DaysId = $"{EveryDayCounterPref} {ID}";
            
            _lastDateKeeper = _dateKeepers.Get<LastDateKeeper>(id);
            
            Load();
        }

        private void Load()
        {
            _days = PlayerPrefs.GetInt(DaysId, 0);
        }

        private void Reset()
        {
            CurrentDay = 0;
        }

        public void Update()
        {
            _lastDateKeeper.Update();
            CurrentDay = GetNextDay();
        }
    }
}