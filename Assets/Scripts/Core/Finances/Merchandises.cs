using System;
using System.Collections.Generic;
using Core.Finances.Payments;
using Core.Finances.Store;
using Core.Finances.Store.Products;
using GameSignals;
using Newtonsoft.Json.Linq;
using UnityEngine.Purchasing;
using Zenject;

namespace Core.Finances
{
    public class Merchandises : ResourcesLoader<Merchandise>
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private Bundles _bundles;
        [Inject] private Moneys.Moneys _moneys;

        protected override string FolderName { get; }
        
        protected override void HandleItem(JToken jToken)
        {
            var id = jToken["Id"].ToString();
                
            var productPackId = jToken["ProductPackId"].ToString();
            var pack = _bundles.GetObject(productPackId);
                
            var productTypeId = jToken["ProductType"].ToString();
            Enum.TryParse(productTypeId, out ProductType productType);
                
            var moneysToken = jToken["Money"];
            var money = _moneys.Create(moneysToken);

            var merchandise = new Merchandise() {Id = id, Price = money, Bundle = pack, ProductType = productType};

            Add(id, merchandise);
        }
        
        public List<Merchandise> GetObjects<TMoney>()
        {
            var merchandises = new List<Merchandise>();
            
            foreach (var merchandise in All)
            {
                var type = merchandise.Value.Price.GetType();
                if (type == typeof(TMoney))
                {
                    merchandises.Add(merchandise.Value);
                }
            }

            return merchandises;
        }
        
        /*protected override void AddListeners()
        {
            base.AddListeners();
            _signalBus.Subscribe<PaymentSignals.Purchase.Successful>(OnPaymentSuccessful);
            _signalBus.Subscribe<PaymentSignals.Purchase.Failed>(OnPaymentFailed);
        }

        private void OnPaymentSuccessful(PaymentSignals.Purchase.Successful obj)
        {
            _signalBus.Fire(new Purchased<Merchandise>(obj.Target));
            _signalBus.Fire(new Taken<Merchandise>(obj.Target));
        }
        private void OnPaymentFailed(PaymentSignals.Purchase.Failed obj)
        {
            _signalBus.Fire(new PurchaseFailed<Merchandise>(obj.Target));
        }*/
        
    }
}