using System;
using Core.Finances.Store;

namespace Core.Finances.Payments
{
    public class PaymentCallback
    {
        public readonly Merchandise Merchandise;
        public readonly Action OnSuccess;
        public readonly Action<string> OnFailure;

        public PaymentCallback(Merchandise merchandise, Action onSuccess, Action<string> onFailure)
        {
            Merchandise = merchandise;
            OnSuccess = onSuccess;
            OnFailure = onFailure;
        }
    }
}