using Core;
using Core.Popups;
using UnityEngine.Playables;
using Zenject;

namespace MatchGame
{
    public class PausePopup : Popup
    {
        [Inject] private SignalBus signalBus;
        
        public override void Show()
        {
            base.Show();
            //signalBus.Fire<GameSignals.Pause>();
        }

        protected override void OnHidden(PlayableDirector obj)
        {
            base.OnHidden(obj);
            //signalBus.Fire<GameSignals.Resume>();
        }
    }
}