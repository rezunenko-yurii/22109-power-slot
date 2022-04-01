using System.Collections.Generic;
using System.Linq;
using Core.Finances.Store;
using Core.Moneys;
using Core.Signals.GameSignals;
using Installers;
using UnityEngine;
using Zenject;

namespace Core.Finances.Payments
{
    public abstract class PaymentSystem<T> : IPaymentSystem, IPreInitializable where T : class, IMoney
    {
        [Inject] private SignalsHelper _signalsHelper;
        [Inject] private Merchandises _merchandises;
        
        protected List<Merchandise> merchandises;

        public abstract void Purchase(Merchandise merchandise);
        public abstract void Restore();

        public virtual void PreInitialize()
        {
            Debug.Log($"{nameof(PaymentSystem<T>)} {nameof(PreInitialize)}");
            
            var p = _merchandises.GetObjects<T>();
            merchandises = p;
        }

        private Merchandise Merchandise(string id)
        {
            return merchandises.FirstOrDefault(c => c.Id.Equals(id));
        }

        protected void OnPurchaseFailed(string id, string reason)
        {
            Debug.Log($"{this.GetType()} OnPurchaseFailed {id} {reason}");

            var merchandise = Merchandise(id);
            merchandise.ResultInfo = reason;
            //_signalsHelper.Fire(typeof(PurchaseFailed<Merchandise>),merchandise);
        }
        
        protected void OnPurchased(string id)
        {
            Debug.Log($"{this.GetType()} OnPurchased {id}");

            var merchandise = Merchandise(id);
            OnPurchased(merchandise);
        }
        
        protected void OnPurchased(Merchandise merchandise)
        {
            Debug.Log($"{this.GetType()} OnPurchased {merchandise.Id}");
            _signalsHelper.Fire(typeof(Purchased<Merchandise>),merchandise);
        }
    }
}