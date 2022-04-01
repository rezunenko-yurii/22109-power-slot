using WalletsImp;

namespace SlotsGame.Scripts.Bets
{
    public abstract class BetSignals
    {
        public class Used : ILocationSignal
        {
            public string LocationId { get; }
            public int Value { get; protected set; }
            public Used(int value, string locationId)
            {
                Value = value;
                LocationId = locationId;
            }
        }
    }
}