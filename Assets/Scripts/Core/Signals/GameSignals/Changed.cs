using Core.Signals.Base;

namespace Core.Signals.GameSignals
{
    public class Changed<TTarget> : GameSignal<TTarget> where TTarget : IIdentifier
    {
        public Changed(TTarget value)
        {
            Target = value;
        }

        public Changed() { }
    }
}