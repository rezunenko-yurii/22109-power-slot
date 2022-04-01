using Lives;
using Zenject;

namespace StateMachine.StateCheckers
{
    public class HasLivesChecker : DualStateChecker
    {
        [Inject] private LivesManager _livesManager;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            Check();
        }

        private void Check()
        {
            if (_livesManager.ActiveLivesAmount > 0)
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