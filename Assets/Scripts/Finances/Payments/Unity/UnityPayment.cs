using Core.Finances.Moneys;
using Core.Finances.Payments;
using Core.Finances.Store;
using UnityEngine;

namespace Finances.Payments.Unity
{
    public class UnityPayment : PaymentSystem<Dollars>
    {
        private UnityStoreListener _storeListener;

        public override void PreInitialize()
        {
            Debug.Log($"{nameof(UnityPayment)} Init");
            base.PreInitialize();
            
            _storeListener = new UnityStoreListener();
            _storeListener.Init(merchandises);
            
            _storeListener.Purchased += OnPurchased;
            _storeListener.PurchaseFailed += OnPurchaseFailed;
        }

        public override void Purchase(Merchandise merchandise)
        {
            Debug.Log($"{nameof(UnityPayment)} Purchase {merchandise.Id}");
            _storeListener.Purchase(merchandise.Id);
        }

        public override void Restore()
        {
            Debug.Log($"{nameof(UnityPayment)} Restore");
            _storeListener.RestorePurchases();
        }
    }
}