using StateMachine;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class LevelAvailChecker : DualStateChecker
    {
        [Inject] private LevelsManager _levelsManager;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            Check();
        }

        private void Check()
        {
            var index = transform.GetSiblingIndex();
            if (_levelsManager.MaxOpened.LevelNum > index)
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