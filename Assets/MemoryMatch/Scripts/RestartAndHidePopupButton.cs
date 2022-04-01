using Zenject;

namespace MemoryMatch.Scripts
{
    public class RestartAndHidePopupButton : PopupHide
    {
        [Inject] private SignalBus _signalBus;

        protected override void OnClick()
        {
            _signalBus.Fire<Core.GameSignals.Restart>();
            base.OnClick();
        }
    }
}