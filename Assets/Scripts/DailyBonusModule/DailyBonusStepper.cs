using Core.Steppers;
using Zenject;

namespace DailyBonusModule
{
    public class DailyBonusStepper : ImageStepper
    {
        [Inject] private DailyBonusesManager _dailyBonusesManager;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            OnUpdated();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            _dailyBonusesManager.counter.Updated += OnUpdated;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _dailyBonusesManager.counter.Updated -= OnUpdated;
        }

        private void OnUpdated()
        {
            Stepper.Set(_dailyBonusesManager.counter.CurrentDay);
        }
    }
}