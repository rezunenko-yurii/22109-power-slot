using Core.Popups;
using UnityEngine.Playables;
using Zenject;

namespace MemoryMatch
{
    public class MemoryMatchPopup : Popup
    {
        [Inject] private SignalBus _signalBus;

        protected override void OnShowed(PlayableDirector obj)
        {
            base.OnShowed(obj);
            _signalBus.Fire<Core.GameSignals.Pause>();
        }

        protected override void OnHidden(PlayableDirector obj)
        {
            base.OnHidden(obj);
            _signalBus.Fire<Core.GameSignals.Resume>();
        }
    }
}