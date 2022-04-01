using Core.Finances.Moneys;
using Core.Finances.Store.Products;
using Core.Popups;
using Core.Signals;
using Core.Signals.Base;
using Core.Signals.GameSignals;
using Finances.Moneys;
using GameSignals;
using TMPro;
using UnityEngine;

public class FreeSpinsWinPopup : Popup
{
    [SerializeField] private TextMeshProUGUI textfield;
    public override void HandleSignal(IGameSignal gameSignal)
    {
        base.HandleSignal(gameSignal);
        HandleSignal(gameSignal as Taken<Bundle>);
    }

    public void HandleSignal(Taken<Bundle> signal)
    {
        Spins spins = signal.Target.Products.Find(x => x.Type.Equals("Spins")) as Spins;
        textfield.text = spins.Amount.ToString();
    }
}