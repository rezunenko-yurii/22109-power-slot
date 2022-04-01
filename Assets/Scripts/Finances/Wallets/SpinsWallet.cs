using Core.Collectables;
using Core.Finances.Wallets;
using Finances.Moneys;

namespace Finances.Wallets
{
    public class SpinsWallet : Wallet<Spins>
    {
        public override bool CanDecreaseInMinus { get; protected set; } = false;

        public SpinsWallet(ICollectableObject<float> collectableObject) : base(collectableObject)
        {
        }
    }
}