using System.Collections.Generic;
using System.Linq;
using Core.Finances.Store;

namespace Core.Finances.Payments
{
    public class PaymentCallbacks
    {
        private List<PaymentCallback> _all = new List<PaymentCallback>();

        public void Add(PaymentCallback paymentCallback)
        {
            _all.Add(paymentCallback);
        }
        
        public void Remove(PaymentCallback paymentCallback)
        {
            _all.Remove(paymentCallback);
        }

        public PaymentCallback PaymentCallback(Merchandise merchandise)
        {
            return _all.First(x => x.Merchandise.Equals(merchandise));
        }

        public List<PaymentCallback> All => _all;
    }
}