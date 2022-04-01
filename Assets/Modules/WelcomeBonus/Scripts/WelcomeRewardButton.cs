using Core.Finances.Store.Products;
using Core.Popups.Buttons;
using Core.Signals.GameSignals;
using GameSignals;
using UnityEngine;
using Zenject;

public class WelcomeRewardButton : HidePopupButton
{
    [SerializeField] private string productPackId;

    [Inject] private SignalBus _signalBus;
    [Inject] private WelcomeBonus.WelcomeBonus _welcomeBonus;
    [Inject] private Bundles _bundles;
    
    private Bundle _products;

    protected override void Initialize()
    {
        base.Initialize();

        _products = _bundles.GetObject(productPackId);
    }

    protected override void OnClick()
    {
        base.OnClick();
        _signalBus.Fire(new Won<Bundle>(_products));
        OnReceived();
    }

    private void OnReceived()
    {
        _welcomeBonus.SetTaken(true);
    }
}
