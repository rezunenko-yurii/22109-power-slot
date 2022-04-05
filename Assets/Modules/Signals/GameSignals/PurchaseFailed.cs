using Core.Signals.Base;
using Core.Signals.GameSignals;

namespace GameSignals
{
    public class PurchaseFailed<TTarget> : GameSignal<TTarget> where TTarget : IIdentifier
    {
        public PurchaseFailed(TTarget value)
        {
            Target = value;
        }
        
        public PurchaseFailed(){}
    }
}