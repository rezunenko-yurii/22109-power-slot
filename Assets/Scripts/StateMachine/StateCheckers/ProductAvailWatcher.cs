using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using UnityEngine;
using Zenject;

namespace StateMachine.StateCheckers
{
    public class ProductAvailWatcher : DualStateChecker
    {
        [SerializeField] protected string productId;

        [Inject] private SignalBus _signalBus;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            Check();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            _signalBus.Subscribe<Taken<Bundle>>(OnReceived);
        }
        
        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _signalBus.Unsubscribe<Taken<Bundle>>(OnReceived);
        }

        private void Check()
        {
            string a = PlayerPrefs.GetString(productId);
            
            if (!string.IsNullOrEmpty(a))
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
            }
        }

        private void OnReceived(Taken<Bundle> taken)
        {
            Check();
        }
    }
}