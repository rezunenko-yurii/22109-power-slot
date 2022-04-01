using Core;
using Core.Finances.Moneys;
using Core.GameScreens;
using Core.Signals.GameSignals;
using GameSignals;
using UnityEngine;
using Zenject;

public class FirstGameOpenReward : AdvancedMonoBehaviour
{
    [Inject] private SignalBus _signalBus;
    [Inject] private ScreensManager _screensManager;

    protected override void Main()
    {
        base.Main();
        string id = $"first_open_{_screensManager.Current.Id}";
        string a = PlayerPrefs.GetString(id, string.Empty);
            
        if (string.IsNullOrEmpty(a))
        {
            Coins coins = new Coins(){Amount = 100f};
            _signalBus.Fire(new Won<Coins>(coins));
                
            PlayerPrefs.SetString(id, "taken");
        }
    }
}