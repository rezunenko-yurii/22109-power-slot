using System;
using UnityEngine;

namespace Core.DataSavers
{
    public class DateTimeOffsetSaver : IDataSaver<DateTimeOffset>
    {
        public string Id { get; set; }
        public DateTimeOffset Value { get; private set; }
        public DateTimeOffset DefaultValue { get; set; } = DateTimeOffset.MinValue;
        
        public void Load()
        {
            string lastDateString = PlayerPrefs.GetString(Id, DefaultValue.ToString());
            Value = DateTimeOffset.Parse(lastDateString);
        }

        public void SetValue(DateTimeOffset value)
        {
            Value = value;
            PlayerPrefs.SetString(Id, Value.ToString());
        }
    }
}