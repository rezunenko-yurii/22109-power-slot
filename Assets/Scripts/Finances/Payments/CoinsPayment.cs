using Core.Finances.Moneys;
using Core.Finances.Payments;
using Core.Finances.Store;
using Core.Finances.Wallets;
using UnityEngine;
using Zenject;

namespace Finances.Payments
{
    public class CoinsPayment : PaymentSystem<Coins>
    {
        [Inject] private CoinsWallet _wallet;
        
        public override void Purchase(Merchandise merchandise)
        {
            Coins coins = merchandise.Price as Coins;

            if (_wallet.CanSubtract(coins))
            {
                _wallet.Subtract(coins);
                OnPurchased(merchandise);
            }
            else
            {
                OnPurchaseFailed(merchandise.Id,"Aren`t enough coins");
            }
        }

        public override void Restore()
        {
            Debug.Log($"{nameof(CoinsPayment)} {nameof(Restore)} can`t restore purchases");
        }
    }
}