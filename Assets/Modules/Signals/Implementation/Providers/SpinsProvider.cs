using Finances.Moneys;
using Finances.Wallets;
using Zenject;

namespace Core.Signals.Implementation.Providers
{
    public class SpinsProvider : ProductProvider<Spins>
    {
        [Inject] private SpinsWallet _spinsWallet;

        public override void Handle(Spins spins)
        {
            _spinsWallet.Add(spins);
        }
    }
}