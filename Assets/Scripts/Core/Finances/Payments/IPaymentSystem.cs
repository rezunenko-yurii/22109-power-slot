using System.Collections.Generic;
using Core.Finances.Store;

namespace Core.Finances.Payments
{
    public interface IPaymentSystem
    {
        void Purchase(Merchandise merchandise);
        void Restore();
    }
}