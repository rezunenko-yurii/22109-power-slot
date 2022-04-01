using Core.Finances.Moneys;
using Core.Finances.Wallets;
using Lives;
using MemoryMatch.Scripts;
using Zenject;

namespace MemoryMatch
{
    public class BuyLifeButton : RestartAndHidePopupButton
    {
        [Inject] private LivesManager _livesManager;
        [Inject] private CoinsWallet _coinsWallet;

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
                _livesManager.TryAddLive();
                base.OnClick();
            }
        }
    }
}