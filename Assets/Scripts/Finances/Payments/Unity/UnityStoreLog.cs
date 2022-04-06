using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Finances.Payments.Unity
{
    public class UnityStoreLog
    {
        public void LogProductsInStoreController(Product[] all)
        {
            Debug.Log("----------------------------------------------------------------------------");
            Debug.Log($"{nameof(UnityStoreLog)} {nameof(LogProductsInStoreController)} All products in store : ");
            
            foreach (var product in all)
            {
                if (product.availableToPurchase)
                {
                    Debug.Log(string.Join(" - ",
                        new[]
                        {
                            $"{nameof(UnityStoreLog)}",
                            product.definition.id,
                            product.definition.type.ToString(),
                            product.metadata.localizedTitle,
                            product.metadata.localizedDescription,
                            product.metadata.isoCurrencyCode,
                            product.metadata.localizedPrice.ToString(),
                            product.metadata.localizedPriceString,
                            product.transactionID,
                            product.receipt
                        }));
                }
                else
                {
                    Debug.LogWarning($"{nameof(UnityStoreLog)} product {product.definition.id} IS NOT AVAILABLE FOR PURCHASING !!!!!!!!!!!");
                }
                
            }
            
            Debug.Log("----------------------------------------------------------------------------");
        }
        
        public void LogProductsInBuilder(HashSet<ProductDefinition> products)
        {
            Debug.Log("----------------------------------------------------------------------------");
            
            Debug.Log($"{nameof(UnityStoreLog)} {nameof(LogProductsInBuilder)} All added products : ");
            foreach (var product in products)
            {
                Debug.Log($"{nameof(UnityStoreLog)} id={product.id} type={product.type.ToString()} storeSpecificId={product.storeSpecificId}");
            }
            
            Debug.Log("----------------------------------------------------------------------------");
        }
        
        public void LogAppleConfigurationInfo(IAppleConfiguration appleConfiguration)
        {
            //IAppleConfiguration appleConfiguration = _builder.Configure<IAppleConfiguration>();
            
            Debug.Log($"{nameof(UnityStoreLog)} {nameof(LogAppleConfigurationInfo)} receipt {appleConfiguration.appReceipt}");
            Debug.Log($"{nameof(UnityStoreLog)} {nameof(LogAppleConfigurationInfo)} canMakePayments {appleConfiguration.canMakePayments}");
        }
        
        public void LogInitializeFailed(InitializationFailureReason error)
        {
            string messega = error switch
            {
                InitializationFailureReason.PurchasingUnavailable => "Billing disabled!",
                InitializationFailureReason.NoProductsAvailable => "No products available for purchase!",
                InitializationFailureReason.AppNotKnown => "App isn`t correctly configured in publisher console",
                _ => throw new ArgumentOutOfRangeException(nameof(error), error, null)
            };
            
            Debug.LogWarning($"-------------- {nameof(UnityStoreListener)} {nameof(LogInitializeFailed)} Billing failed to initialize !!!!!!!!!! \n Reason={messega}");
        }
        
        public void LogLastPurchaseErrorDescription(ITransactionHistoryExtensions purchaseHistory)
        {
            var errorCode = purchaseHistory.GetLastStoreSpecificPurchaseErrorCode();
            var description = purchaseHistory.GetLastPurchaseFailureDescription();
            
            Debug.LogWarning($"{nameof(UnityStoreListener)} Store specific error code:{errorCode} / description={description?.message}");
        }
    }
}