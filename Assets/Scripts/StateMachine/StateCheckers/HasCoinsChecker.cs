using Core.Finances.Moneys;
using Core.Finances.Wallets;
using UnityEngine;
using Zenject;

namespace StateMachine.StateCheckers
{
    public class HasCoinsChecker : DualStateChecker
    {
        [SerializeField] private float _amount;
        [Inject] private CoinsWallet _coinsWallet;
        
        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            Check();
        }

        private void Check()
        {
            if (_coinsWallet.HasOnBalance(_amount))
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