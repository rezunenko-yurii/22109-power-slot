namespace WalletsImp
{
    public sealed class SpinsSignals
    {
        public abstract class SpinsBaseSignal : ILocationSignal
        {
            public string LocationId { get; protected set; }

            protected SpinsBaseSignal(string locationId)
            {
                LocationId = locationId;
            }
        }
        
        public class Spent : SpinsBaseSignal
        {
            public Spent(string locationId) : base(locationId) { }
        }
    }
}