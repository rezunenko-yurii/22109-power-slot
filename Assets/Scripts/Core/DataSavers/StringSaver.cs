using UnityEngine;

namespace Core.DataSavers
{
    public class StringSaver : IDataSaver<string>
    {
        public string Id { get; set; }
        public string Value { get; private set; }
        public string DefaultValue { get; set; }
        
        public void Load()
        {
            Value = PlayerPrefs.GetString(Id, DefaultValue);
        }

        public void SetValue(string value)
        {
            Value = value;
            PlayerPrefs.SetString(Id, Value);
        }
    }
}