using System;
using System.Collections.Generic;
using Core.Finances;
using Core.Finances.Moneys;
using Core.Finances.Payments;
using Core.Finances.Store;
using Finances.Payments.Unity;
using Installers;
using Zenject;

namespace Finances.Payments
{
    public class Payments : IPreInitializable
    {
        [Inject] private CoinsPayment _coinsPayment;
        [Inject] private UnityPayment _unityPayment;
        [Inject] private Merchandises _merchandises;
        
        private Dictionary<Type, IPaymentSystem> _dictionary;
        
        public void PreInitialize()
        {
            _dictionary = new Dictionary<Type, IPaymentSystem>()
            {
                {typeof(Coins), _coinsPayment},
                {typeof(Dollars), _unityPayment}
            };
        }
        
        public IPaymentSystem PaymentSystem(Type currency)
        {
            return _dictionary[currency];
        }
        
        public void Purchase(string merchandiseId)
        {
            var merchandise = _merchandises.GetObject(merchandiseId);
            Purchase(merchandise);
        }
        
        public void Purchase(Merchandise model)
        {
            var paymentSystem = PaymentSystem(model.Price.GetType());
            paymentSystem.Purchase(model);
        }

        public void Restore()
        {
            foreach (var paymentSystem in _dictionary)
            {
                paymentSystem.Value.Restore();
            }
        }
    }
}