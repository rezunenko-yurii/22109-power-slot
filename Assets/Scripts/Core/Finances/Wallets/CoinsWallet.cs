using Core.Collectables;
using Core.Finances.Moneys;

namespace Core.Finances.Wallets
{
    public class CoinsWallet : Wallet<Coins>
    {
        public override bool CanDecreaseInMinus { get; protected set; } = false;
        
        public CoinsWallet(ICollectableObject<float> collectableObject) : base(collectableObject)
        {
            
        }
    }
}