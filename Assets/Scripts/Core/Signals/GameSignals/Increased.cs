using Core.Signals.Base;

namespace Core.Signals.GameSignals
{
    public class Increased<TTarget> : GameSignal<TTarget> where TTarget : IIdentifier
    {
        public Increased(TTarget value)
        {
            Target = value;
        }

        public Increased() { }
    }
}