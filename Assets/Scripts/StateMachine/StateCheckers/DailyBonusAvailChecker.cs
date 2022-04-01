using DailyBonusModule;
using Zenject;

namespace StateMachine.StateCheckers
{
    public class DailyBonusAvailChecker : DualStateChecker
    {
        [Inject] private DailyBonusesManager _dailyBonusesManager;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            Check();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            _dailyBonusesManager.nextDateKeeper.Updated += Check;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _dailyBonusesManager.nextDateKeeper.Updated -= Check;
        }

        private void Check()
        {
            if (_dailyBonusesManager.IsBonusAvailable())
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
            }
        }
    }
}