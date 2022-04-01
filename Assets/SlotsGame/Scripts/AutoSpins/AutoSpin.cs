using System;
using SlotsGame.Scripts.AutoSpins.Modes;
using Zenject;

namespace SlotsGame.Scripts.AutoSpins
{
    public class AutoSpin
    {
        public event Action<AutoSpinType> StateChanged;
        [Inject] private AutoSpinModesFactory _factory;
        private AutoSpinMode _mode;

        [Inject]
        private void Init()
        {
            ChangeMode(AutoSpinType.Off);
        }

        public AutoSpinType Type => _mode.Type;

        public void TransitSilently(AutoSpinType type)
        {
            ChangeMode(type);
        }
        
        public void TransitionTo(AutoSpinType type, int spinsAmount = 0)
        {
            if (_mode.Type.Equals(type))
            {
                TryMerge(spinsAmount);
                return;
            }

            if (!_mode.CanChangeState())
            {
                return;
            }

            ChangeMode(type);
            
            TryMerge(spinsAmount);
            
            StateChanged?.Invoke(Type);
        }

        private void ChangeMode(AutoSpinType type)
        {
            _mode?.OnContextChanged();
            _mode = _factory.Create(type);
            _mode.SetContext(this);
        }

        private void TryMerge(int spinsAmount)
        {
            if (_mode.CanMerge())
            {
                _mode.Merge(spinsAmount);
            }
        }
    }

    public enum AutoSpinType
    {
        Off,
        Infinity,
        ForcedAmount
    }
}