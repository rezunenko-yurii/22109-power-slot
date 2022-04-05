using System;
using DailyBonusModule;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DailyBonusNextToOpenState : DailyBonusState
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI textfield;
    
    [Inject] private DailyBonusesManager _bonusesManager;
    
    protected override DailyBonusStates State { get; } = DailyBonusStates.Empty;
    public override void Apply()
    {
        Context.Skin.sprite = sprite;

        button.gameObject.SetActive(true);
        _bonusesManager.Timer.Counting += OnCounting;
    }

    public override void BeforeChanged()
    {
        button.gameObject.SetActive(false);
        _bonusesManager.Timer.Counting -= OnCounting;
    }

    public override bool CanApply(int itemDay, int currentDay, int passedDay)
    {
        return currentDay == itemDay && passedDay == 0;
    }
    
    private void OnCounting(double seconds)
    {
        OnCounting(TimeSpan.FromSeconds(seconds));
    }

    private void OnCounting(TimeSpan obj)
    {
        textfield.text = $"{obj.Hours:00}:" +
                         $"{obj.Minutes:00}:" +
                         $"{obj.Seconds:00}";
    }
}
