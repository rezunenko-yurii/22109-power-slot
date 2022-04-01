using Modules.Timers.Scripts;
using StateMachine;
using Zenject;

namespace WheelLib
{
    public class WheelTimerSwitcher : DualStateChecker
    {
        [Inject] private Timers _timers;
        private MemoryTimer _timer;

        protected override void Initialize()
        {
            base.Initialize();
            _timer = (MemoryTimer) _timers.GetObject("wheel");
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            
            if (_timer.IsExpired)
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
                _timer.Over += OnOver;
            }
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            
            _timer.Over -= OnOver;
        }

        private void OnOver()
        {
            SetAllActive();
        }
    }
}