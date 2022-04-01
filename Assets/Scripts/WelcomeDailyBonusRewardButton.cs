using Core.Popups.Buttons;
using DailyBonusModule;
using Zenject;

public class WelcomeDailyBonusRewardButton : HidePopupButton
{
    [Inject] private WelcomeBonus.WelcomeBonus _welcomeBonus;
    [Inject] private DailyBonusesManager _dailyBonusesManager;
        
    protected override void OnClick()
    {
        base.OnClick();
        OnReceived();
    }
        
    private void OnReceived()
    {
        _dailyBonusesManager.GiveBonus();
        _welcomeBonus.SetTaken(true);
    }
}