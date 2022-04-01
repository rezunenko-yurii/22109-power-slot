using Conditions.Models;
using Core.Buttons;
using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using GameSignals;
using UnityEngine;
using Zenject;

public class GoalRewardButton : AdvancedButtonUI
{
    [SerializeField] private ChallengeModel _model;
    
    [Inject] private SignalBus _signalBus;
    [Inject] private Bundles _bundles;
    protected override void OnClick()
    {
        base.OnClick();
        
        var pack = _bundles.GetObject(_model.Rewards);
        _signalBus.Fire(new Won<Bundle>(pack));
        //_productBundles.Give(pack);
        _model.IsRewardTaken = true;
    }
}
