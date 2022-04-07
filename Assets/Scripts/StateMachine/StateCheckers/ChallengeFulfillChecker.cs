using Modules.Challenges.Scripts;
using UnityEngine;
using Zenject;

namespace StateMachine
{
    public class ChallengeFulfillChecker : DualStateChecker
    {
        [Inject] private Challenges _challenges;
        [SerializeField] private string _challengeId;
        [SerializeField] protected string _locationId = "";
        private Challenge _challenge;

        protected override void Initialize()
        {
            base.Initialize();
            _challenge = _challenges.GetObject(_challengeId);
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();

            if (NeedToCheckLocation())
            {
                if (IsLocationAvailable())
                {
                    CheckChallenge();
                }
                else
                {
                    SetAllActive();
                }
            }
            else
            {
                CheckChallenge();
            }
        }

        private void CheckChallenge()
        {
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

        private bool IsLocationAvailable()
        {
            string a = PlayerPrefs.GetString(_locationId);
            return !string.IsNullOrEmpty(a);
        }

        private bool NeedToCheckLocation()
        {
            return !_locationId.Equals("");
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