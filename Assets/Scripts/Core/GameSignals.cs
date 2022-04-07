using Core.Signals.GameSignals;

namespace Core
{
    public abstract class GameSignals
    {
        public class Pause { }
        public class Resume { }
        public class Restart { }
        public class NextLevel { }
        public class UserInputPause : IGameSignal{ }
        public class UserInputResume : IGameSignal{ }
    }

    public enum LockType
    {
        Global,
        Game
    } 
}