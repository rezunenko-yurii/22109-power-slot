using Core.Finances.Store;
using Core.Popups;
using Core.Signals.GameSignals;
using GameSignals;
using UnityEngine;
using Zenject;

public class SingleProductPopup : Popup
{
    [SerializeField] private string _merchandiseId;

    [Inject] private SignalBus _signalBus;
    [Inject] private PopupsManager _popupsManager;
    
    protected override void AddListeners()
    {
        base.AddListeners();
        _signalBus.Subscribe<Purchased<Merchandise>>(OnReceived);
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        _signalBus.Unsubscribe<Purchased<Merchandise>>(OnReceived);
    }

    private void OnReceived(Purchased<Merchandise> successful)
    {
        if (successful.Target.Id.Equals(_merchandiseId))
        {
            _popupsManager.Hide(this);
        }
    }
}