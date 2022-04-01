using Challenges;
using Conditions;
using Conditions.Models;
using Modules.Challenges.Scripts;
using UnityEngine;
using Zenject;

namespace StateMachine
{
    public class ConditionFulfillChecker : DualStateChecker
    {
        //[SerializeField] protected ChallengeModel model;
        //[Inject] private ConditionsImp.Conditions conditions;
        private Challenge _challenge;
        
        protected override void Initialize()
        {
            base.Initialize();
            //_challenge = conditions.All[model];
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            
            /*if (model.IsFulfilled)
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
                _challenge.Fulfilled += OnFulfilled;
            }*/
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            
            // if (_challenge != null)
            // {
            //     _challenge.Fulfilled -= OnFulfilled; 
            // }
        }

        private void OnFulfilled()
        {
            SetAllActive();
        }
    }
}