using Core.Signals.Base;

namespace Core.Signals.GameSignals
{
    public class Taken<TTarget> : GameSignal<TTarget> where TTarget : IIdentifier
    {
        public Taken(TTarget value)
        {
            Target = value;
        }

        public Taken() { }
    }
}