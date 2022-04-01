using Core.Signals.Base;

namespace Core.Signals.GameSignals
{
    public class Purchased<TTarget> : GameSignal<TTarget> where TTarget : IIdentifier
    {

        public Purchased(TTarget value)
        {
            Target = value;
        }
        
        public Purchased(){}
    }
}