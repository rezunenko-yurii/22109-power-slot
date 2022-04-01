using Core.Signals.Base;

namespace Core.Signals.GameSignals
{
    public interface IGameSignal { }

    public class GameSignal : IGameSignal
    {
        public object Target { get; set; }
    }
    
    public class GameSignal<TTarget> : GameSignal where TTarget : IIdentifier
    {
        public new TTarget Target
        {
            get
            {
                return (TTarget) base.Target;
            }

            set
            {
                base.Target = value;
            }
        }
    }
}