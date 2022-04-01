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

public class FreeSpinsAndCoinsWinPopup : Popup
{
    [SerializeField] private TextMeshProUGUI coinsTextfield;
    [SerializeField] private TextMeshProUGUI spinsTextfield;
    public override void HandleSignal(IGameSignal gameSignal)
    {
        base.HandleSignal(gameSignal);
        HandleSignal(gameSignal as Taken<Bundle>);
    }

    public void HandleSignal(Taken<Bundle> signal)
    {
        Coins coins = signal.Target.Products.Find(x => x.Type.Equals("Coins")) as Coins;
        Spins spins = signal.Target.Products.Find(x => x.Type.Equals("Spins")) as Spins;

        coinsTextfield.text = coins.Amount.ToString();
        spinsTextfield.text = spins.Amount.ToString();
    }
}