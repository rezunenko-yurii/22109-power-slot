using Zenject;

namespace MemoryMatch
{
    public class OpenNextLevel : PopupHide
    {
        [Inject] private SignalBus _signalBus;
        protected override void OnClick()
        {
            _signalBus.Fire<Core.GameSignals.NextLevel>();
            base.OnClick();
        }
    }
}