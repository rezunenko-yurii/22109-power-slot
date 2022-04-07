using Core.Popups.Buttons;
using DailyBonusModule;
using UnityEngine;
using UnityEngine.Playables;
using Zenject;

public class WelcomeDailyBonusRewardButton : HidePopupButton
{
    [Inject] private WelcomeBonus.WelcomeBonus _welcomeBonus;
    [Inject] private DailyBonusesManager _dailyBonusesManager;
    [SerializeField] private PlayableDirector _director;
        
    protected override void OnClick()
    {
        _director.stopped += OnStoped;
        _director.Play();
    }

    private void OnStoped(PlayableDirector obj)
    {
        _director.stopped -= OnStoped;
        OnReceived();
        
        base.OnClick();
    }

    private void OnReceived()
    {
        _dailyBonusesManager.GiveBonus();
        _welcomeBonus.SetTaken(true);
    }
}