using Modules.Challenges.Scripts;
using UnityEngine;
using Zenject;

namespace StateMachine
{
    public class ChallengeFulfillChecker : DualStateChecker
    {
        [Inject] private Challenges _challenges;
        [SerializeField] private string _challengeId;
        private Challenge _challenge;

        protected override void Initialize()
        {
            base.Initialize();
            _challenge = _challenges.GetObject(_challengeId);
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            
            if (_challenge.IsFulFilled)
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
                _challenge.Fulfilled += OnFulfilled;
            }
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            
            if (_challenge != null)
            {
                _challenge.Fulfilled -= OnFulfilled; 
            }
        }

        private void OnFulfilled()
        {
            SetAllActive();
        }
    }
}