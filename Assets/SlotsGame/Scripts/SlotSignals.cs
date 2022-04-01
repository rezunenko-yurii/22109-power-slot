using Core.Signals.GameSignals;

namespace SlotsGame.Scripts
{
    public abstract class SlotSignals 
    {
        public class RoundStarted : IGameSignal{ }
        public class SpinStarted : IGameSignal{ }
        public class SpinEnded : IGameSignal{ }
        public class EffectsStarted : IGameSignal{ }
        public class EffectsEnded : IGameSignal{ }
        public class RoundEnded : IGameSignal{ }
    }
}
