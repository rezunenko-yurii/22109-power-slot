using Core.DataSavers;

namespace Core.Collectables
{
    public class IntCollectableObject : ICollectableObject<int>
    {
        private readonly IntSaver _saver;
        
        public int Amount
        {
            get => _saver.Value;
            set => _saver.SetValue(value);
        }
        
        public IntCollectableObject(string id, int defaultValue)
        {
            _saver = new IntSaver{Id = id, DefaultValue = defaultValue};
            _saver.Load();
        }
        public int Remainder(int value)
        {
            return Amount - value;
        }

        public bool IsRemainderPositive(int value)
        {
            return Remainder(value) >= 0;
        }

        public void Increase()
        {
            Amount++;
        }

        public void Increase(int amount)
        {
            Amount += amount;
        }

        public void Decrease()
        {
            Amount--;
        }

        public void Decrease(int amount)
        {
            Amount -= amount;
        }

        public void Reset()
        {
            Amount = 0;
        }
    }
}