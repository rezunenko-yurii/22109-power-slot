using System;
using UnityEngine;

namespace Core.DataSavers
{
    public class BoolSaver : IDataSaver<bool>
    {
        public string Id { get; set; }
        public bool Value { get; private set; }
        public bool DefaultValue { get; set; }
        
        public void Load()
        {
            int defValue = Convert.ToInt32(DefaultValue);
            int loadedValue = PlayerPrefs.GetInt(Id, defValue);
            
            Value = Convert.ToBoolean(loadedValue);
            
        }
        public void SetValue(bool value)
        {
            Value = value;
            PlayerPrefs.SetInt(Id, Convert.ToInt32(Value));
        }
    }
}