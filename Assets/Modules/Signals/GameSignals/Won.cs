using Core.Signals.Base;

namespace Core.Signals.GameSignals
{
    public class Won<TTarget> : GameSignal<TTarget> where TTarget : IIdentifier
    {
        public Won(TTarget value)
        {
            Target = value;
        }
        
        public Won(){}
    }
}