using Core.Buttons;
using DailyBonusModule;
using UnityEngine;
using Zenject;

public class DailyBonusCollectButton : AdvancedButtonUI
{
    [Inject] private DailyBonusesManager _dailyBonusesManager;

    protected override void OnClick()
    {
        base.OnClick();
        GiveBonus();
    }

    [ContextMenu("GiveBonus")]
    private void GiveBonus()
    {
        _dailyBonusesManager.GiveBonus();
    }
}
