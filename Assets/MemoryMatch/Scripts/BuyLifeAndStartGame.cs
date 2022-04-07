using Core.Finances.Wallets;
using Lives;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class BuyLifeAndStartGame : ShowScreenButton
    {
        [Inject] private LivesManager _livesManager;
        [Inject] private CoinsWallet _coinsWallet;

        private float _price = 100;

        protected override void OnClick()
        {
            if (_coinsWallet.HasOnBalance(_price))
            {
                _coinsWallet.Subtract(_price);
                _livesManager.TryAddLive();
                base.OnClick();
            }
        }
    }
}