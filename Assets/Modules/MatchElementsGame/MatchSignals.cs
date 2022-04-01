namespace MatchGame
{
    public abstract class MatchSignals
    {
        public class MatchBoosterSignal
        {
            public readonly string Value;
            public MatchBoosterSignal(string value)
            {
                Value = value;
            }
        }

        public class Restart { }
    }
}