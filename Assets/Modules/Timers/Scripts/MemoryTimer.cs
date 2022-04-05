using System;
using Modules.Dates;
using Zenject;

namespace Modules.Timers.Scripts
{
    public class MemoryTimer : Timer
    {
        [Inject] private DateKeepers _dateKeepers;
        
        public string Id { get; set; }
        public int Duration { get; set; }

        public NextDateKeeper Keeper { get; private set; }

        public bool IsExpired => Keeper.IsExpired();

        public override void Init()
        {
            base.Init();
            Keeper = _dateKeepers.Get<NextDateKeeper>(Id);
        }

        public void Resume()
        {
            var a = LeftTimeSpan();
            Start(a.TotalSeconds);
        }
        
        public void StartFromBeginning()
        {
            Keeper.AddSecondsFromNow(Duration);
            Start(Duration);
        }

        public TimeSpan LeftTimeSpan()
        {
            return Keeper.Date - DateTimeOffset.Now;
        }
    }
}