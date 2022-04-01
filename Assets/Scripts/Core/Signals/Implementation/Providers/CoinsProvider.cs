using Core.Finances.Moneys;
using Core.Finances.Wallets;
using Zenject;

namespace Core.Signals.Implementation.Providers
{
    public class CoinsProvider : ProductProvider<Coins>
    {
        [Inject] private CoinsWallet _coinsWallet;
        
        public override void Handle(Coins coins)
        {
            _coinsWallet.Add(coins);
        }
    }
}