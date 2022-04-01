using Modules.Dates;
using UnityEngine;
using Zenject;

namespace Modules.Timers.Scripts
{
    public class MemoryTimer : Timer
    {
        [Inject] private DateKeepers _dateKeepers;
        public NextDateKeeper Keeper { get; private set; }
        
        public override void Init(string id)
        {
            base.Init(id);
            
            Keeper = _dateKeepers.Get<NextDateKeeper>(id);
            if (IsInited)
            {
                Debug.LogWarning("MemoryTimer is already inited");
                return;
            }
            
            //Keeper.Updated += OnDateUpdated;
            SetTimer(Keeper.Date);
        }
        
        private void OnDateUpdated()
        {
            SetTimer(Keeper.Date);
        }

        public override void Restart()
        {
            base.Restart();
            Keeper.AddSecondsFromNow(Duration);
        }
    }
}