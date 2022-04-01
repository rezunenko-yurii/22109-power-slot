using UnityEngine;

namespace Core.DataSavers
{
    public class IntSaver : IDataSaver<int>
    {
        public string Id { get; set; }
        public int Value { get; private set; }
        public int DefaultValue { get; set; } = 0;

        public void Load()
        {
            Value = PlayerPrefs.GetInt(Id, DefaultValue);
        }

        public void SetValue(int value)
        {
            Value = value;
            PlayerPrefs.SetInt(Id, Value);
        }
    }
}