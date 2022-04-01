using Core;
using Core.Finances.Moneys;
using Finances.Moneys;
using Finances.Wallets;
using TMPro;
using UnityEngine;
using Zenject;

public class FreeSpinsPanel : AdvancedMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;
    
    [Inject] private SignalBus _signalBus;
    [Inject] private SpinsWallet _spinsWallet;

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        ChangeText(_spinsWallet.Balance());
    }

    protected override void AddListeners()
    {
        _signalBus.Subscribe<MoneySignals.Changed<Spins>>(OnChanged);
    }
    
    protected override void RemoveListeners()
    {
        _signalBus.Unsubscribe<MoneySignals.Changed<Spins>>(OnChanged);
    }

    private void OnChanged(MoneySignals.Changed<Spins> spins)
    {
        ChangeText(spins.Value);
    }
    
    private void ChangeText(float amount)
    {
        textField.text = amount.ToString();
    }
}
