using Core.DataSavers;
using UnityEngine;

namespace Core.Collectables
{
    //[CreateAssetMenu(fileName = "FloatCollectableObject", menuName = "CollectableObjects/Float")]
    public class FloatCollectableObject : ICollectableObject<float>
    {
        private readonly FloatSaver _saver;
        [field: SerializeField]public float Amount
        {
            get => _saver.Value;
            set => _saver.SetValue(value);
        }
        
        public FloatCollectableObject(string id, int defaultValue)
        {
            _saver = new FloatSaver{Id = id, DefaultValue = defaultValue};
            _saver.Load();
        }

        public float Remainder(float value)
        {
            return Amount - value;
        }

        public bool IsRemainderPositive(float value)
        {
            return Remainder(value) >= 0f;
        }

        public void Increase()
        {
            Amount++;
        }

        public void Increase(float amount)
        {
            Amount += amount;
        }

        public void Decrease()
        {
            Amount--;
        }

        public void Decrease(float amount)
        {
            Amount -= amount;
        }

        public void Reset()
        {
            Amount = 0;
        }
    }
}