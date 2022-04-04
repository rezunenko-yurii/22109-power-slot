using System;
using Core.DataSavers;
using UnityEngine;

namespace Modules.Dates
{
    public abstract class DateKeeper
    {
        protected abstract string DateCounterPref { get; }
        
        public Action Updated;
        private DateTimeOffsetSaver _saver;
        
        public DateKeeper(){}

        public DateTimeOffset Date
        {
            get => _saver.Value;
            protected set
            {
                _saver.SetValue(value);
                Updated?.Invoke();
            }
        }

        public void SaveCurrentTime()
        {
            Date = DateTimeOffset.Now;
        }
        
        public void Init(string id)
        {
            _saver = new DateTimeOffsetSaver() { Id = $"{DateCounterPref} {id}"};
            _saver.Load();
        }
    }
}