using Core.DataSavers;
using Modules.Dates;

namespace Boosters
{
    public class Booster
    {
        protected string Type { get; }
        private float _amount;
        private NextDateKeeper _dateKeeper;
        private FloatSaver _saver;

        public Booster(NextDateKeeper dateKeeper)
        {
            _dateKeeper = dateKeeper;
            
            _saver = new FloatSaver{Id = Type, DefaultValue = 1};
            _saver.Load();
            
            _amount = _saver.Value;
        }

        public float Use()
        {
            if (_dateKeeper.IsExpired())
            {
                Reset();
            }

            return _amount;
        }

        public void Add(int amount, int hours)
        {
            _amount = amount;

            if (_dateKeeper.IsExpired())
            {
                _dateKeeper.Reset();
            }
            
            _dateKeeper.AddHours(hours);
        }

        private void Reset()
        {
            _amount = 1;
        }
    }
}