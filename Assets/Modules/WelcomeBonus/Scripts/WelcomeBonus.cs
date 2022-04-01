using Core.DataSavers;

namespace WelcomeBonus
{
    public class WelcomeBonus
    {
        private BoolSaver _saver;

        public WelcomeBonus()
        {
            _saver = new BoolSaver(){Id = ModuleType.WelcomeBonus.ToString()};
            _saver.Load();
        }

        public bool IsTaken => _saver.Value;

        public void SetTaken(bool value)
        {
            _saver.SetValue(value);
        }
    }
}