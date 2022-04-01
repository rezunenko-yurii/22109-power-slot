using Core.Buttons;
using GameCenter.Signals;
using Zenject;

public class ShowLeaderboardButton : AdvancedButtonUI
{
    [Inject] private SignalBus _signalBus;
    protected override void OnClick()
    {
        base.OnClick();
        _signalBus.Fire<ShowLeaderboard>();
    }
}
