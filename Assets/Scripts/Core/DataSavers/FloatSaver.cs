using UnityEngine;

namespace Core.DataSavers
{
    public class FloatSaver : IDataSaver<float>
    {
        public string Id { get; set; }
        public float Value { get; private set; }
        public float DefaultValue { get; set; } = 0f;
        public void Load()
        {
            Value = PlayerPrefs.GetFloat(Id, DefaultValue);
        }

        public void SetValue(float value)
        {
            Value = value;
            PlayerPrefs.SetFloat(Id, Value);
        }
    }
}