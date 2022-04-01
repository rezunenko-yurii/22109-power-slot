using Core.Buttons;
using Zenject;

namespace MatchGame
{
    public class RestartButton : PopupHide
    {
        [Inject] private SignalBus signalBus;
        protected override void OnClick()
        {
            base.OnClick();
            signalBus.Fire<MatchSignals.Restart>();
        }
    }
}