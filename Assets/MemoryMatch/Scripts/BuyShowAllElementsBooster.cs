using Core;
using Core.Finances.Moneys;
using Core.Finances.Wallets;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class BuyShowAllElementsBooster : PopupHide
    {
        [Inject] private CoinsWallet _coinsWallet;
        [Inject] private SignalBus _signalBus;
        
        private Coins _coins;
        
        protected override void Initialize()
        {
            base.Initialize();
            _coins = new Coins {Amount = 100};
        }
        
        protected override void OnClick()
        {
            if (_coinsWallet.HasOnBalance(_coins))
            {
                _coinsWallet.Subtract(_coins);
                base.OnClick();
            }
        }

        protected override void OnHidden(IUIObject obj)
        {
            base.OnHidden(obj);
            _signalBus.Fire<ShowAllElementsSignal>();
        }
    }
}