using Conditions.Models;
using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using GameSignals;
using UnityEngine;
using Zenject;

namespace StateMachine.StateCheckers
{
    public class ChallengeRewardAvailableChecker : DualStateChecker
    {
        //[SerializeField] protected ChallengeModel model;
        [Inject] private SignalBus _signalBus;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();

            /*if (model.IsRewardTaken)
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
                _signalBus.Subscribe<Taken<Bundle>>(OnReceived);
            }*/
        }

        private void OnReceived(Taken<Bundle> obj)
        {
            /*if (obj.Target.Id.Equals(model.Rewards))
            {
                SetAllActive();
            }*/
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            _signalBus.TryUnsubscribe<Taken<Bundle>>(OnReceived);
        }
    }
}