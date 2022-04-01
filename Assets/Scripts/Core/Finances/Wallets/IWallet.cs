using Core.Moneys;

namespace Core.Finances.Wallets
{
    public interface IWallet
    {
        float Balance();
        void Add(IMoney amount);
        void Subtract(IMoney money);
        bool CanSubtract(IMoney money);
        bool CanDecreaseInMinus { get; }
        void Reset();
    }
}