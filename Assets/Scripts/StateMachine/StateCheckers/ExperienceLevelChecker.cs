using LevelsModule;
using UnityEngine;
using Zenject;

namespace StateMachine.StateCheckers
{
    public abstract class ExperienceLevelChecker : DualStateChecker
    {
        [SerializeField] protected int level;
        [Inject] protected ExperienceManager ExperienceManager;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            
            if (CheckCondition())
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
            }
            
            ExperienceManager.Increased += OnManagerIncreased;
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            
            ExperienceManager.Increased -= OnManagerIncreased;
        }


        protected abstract bool CheckCondition();

        private void OnManagerIncreased(int obj)
        {
            if (CheckCondition())
            {
                SetAllInactive();
            }
        }
    }
}