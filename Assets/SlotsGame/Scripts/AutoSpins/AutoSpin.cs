using System;
using SlotsGame.Scripts.AutoSpins.Modes;
using Zenject;

namespace SlotsGame.Scripts.AutoSpins
{
    public class AutoSpin
    {
        public event Action<AutoSpinType> StateChanged;
        public event Action<AutoSpinType> StateChangedSilently;
        [Inject] private AutoSpinModesFactory _factory;
        private AutoSpinMode _mode;

        [Inject]
        private void Init()
        {
            ChangeMode(AutoSpinType.Off);
        }

        public AutoSpinType Type => _mode.Type;

        private void Transit(AutoSpinType type, int spinsAmount = 0)
        {
            if (_mode.Type.Equals(type))
            {
                //TryMerge(spinsAmount);
                return;
            }

            ChangeMode(type);
            TryMerge(spinsAmount);
        }
        public void TransitSilently(AutoSpinType type, int spinsAmount = 0)
        {
            Transit(type,spinsAmount);
            StateChangedSilently?.Invoke(Type);
        }

        public void TransitionToForcibly(AutoSpinType type, int spinsAmount = 0)
        {
            TransitSilently(type,spinsAmount);
            StateChanged?.Invoke(Type);
        }
        
        public void TransitionTo(AutoSpinType type, int spinsAmount = 0)
        {
            if (!_mode.CanChangeState())
            {
                return;
            }
            
            TransitionToForcibly(type, spinsAmount);
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