using System;
using System.Collections.Generic;
using Core.Finances.Store;
using Core.Finances.Store.Products;
using UnityEngine;
using UnityEngine.Purchasing;
using Product = UnityEngine.Purchasing.Product;

namespace Finances.Payments.Unity
{
    public class UnityStoreListener : IStoreListener
    {
        public event Action<string> Purchased;
        public event Action<string, string> PurchaseFailed;
        
        private IAppleExtensions _appleProvider;
        private ITransactionHistoryExtensions _purchaseHistory;
        private IStoreController _storeController;
        
        private ConfigurationBuilder _builder;

        private UnityStoreLog _log;

        public void Init(List<Merchandise> models)
        {
            _builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            AddProducts(models);
           
           _log = new UnityStoreLog();
           _log.LogAppleConfigurationInfo(_builder.Configure<IAppleConfiguration>());
           _log.LogProductsInBuilder(_builder.products);
           
            UnityPurchasing.Initialize(this, _builder);
        }
        
        private void AddProducts(List<Merchandise> models)
        {
            Debug.Log($"{nameof(UnityStoreListener)} {nameof(AddProducts)} Adding products... ");
            
            foreach (var shopItem in models)
            {
                _builder.AddProduct(shopItem.Id, shopItem.ProductType);
            }
        }
        
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            Debug.Log($"{nameof(UnityStoreListener)} {nameof(OnInitialized)}");
            
            _storeController = controller;
            _log.LogProductsInStoreController(controller.products.all);
            
            _appleProvider = extensions.GetExtension<IAppleExtensions>();
            _appleProvider.RegisterPurchaseDeferredListener(OnDeferred);

            _purchaseHistory = extensions.GetExtension<ITransactionHistoryExtensions>();
        }
        
        private void OnDeferred(Product item)
        {
            Debug.Log($"{nameof(UnityStoreListener)} Purchase deferred: " + item.definition.id);
        }
        
        public void OnInitializeFailed(InitializationFailureReason error)
        {
            _log.LogInitializeFailed(error);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            Product product = purchaseEvent.purchasedProduct;
            Debug.Log($"{nameof(UnityStoreListener)} {nameof(ProcessPurchase)} Product {product.definition.id} is successfully payed. Receipt={product.receipt}");
            
            Purchased?.Invoke(product.definition.id);
            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.LogWarning($"{nameof(UnityStoreListener)} {nameof(OnPurchaseFailed)} Product {product.definition.id} PAYMENT IS FAILED!!! Reason={failureReason}");
            _log.LogLastPurchaseErrorDescription(_purchaseHistory);
            
            PurchaseFailed?.Invoke(product.definition.id, GetReason(failureReason));
        }

        private string GetReason(PurchaseFailureReason failureReason) => failureReason switch
        {
            PurchaseFailureReason.PurchasingUnavailable => "Purchasing Unavailable",
            PurchaseFailureReason.ExistingPurchasePending => "Existing Purchase Pending",
            PurchaseFailureReason.ProductUnavailable => "Product Unavailable",
            PurchaseFailureReason.SignatureInvalid => "Signature Invalid",
            PurchaseFailureReason.UserCancelled => "You Cancelled Purchasing",
            PurchaseFailureReason.PaymentDeclined => "Payment Declined",
            PurchaseFailureReason.DuplicateTransaction => "Duplicate Transaction",
            PurchaseFailureReason.Unknown => "Unknown Error",
            _ => throw new ArgumentOutOfRangeException(nameof(failureReason), failureReason, null)
        };

        public void Purchase(string id)
        {
            var product = _storeController.products.WithID(id);
            _storeController.InitiatePurchase(product);
        }
        public void RestorePurchases()
        {
            Debug.Log($"{nameof(UnityStoreListener)} RestorePurchases started ...");
            _appleProvider.RestoreTransactions((result) =>
            {
                Debug.Log($"{nameof(UnityStoreListener)} RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
    }
}