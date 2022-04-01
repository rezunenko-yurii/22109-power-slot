using System.Globalization;
using Core;
using Core.Finances.Moneys;
using Core.Finances.Wallets;
using Core.Signals.GameSignals;
using TMPro;
using UnityEngine;
using Zenject;

public class MoneyPanel : AdvancedMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountText;
    
    [Inject] private CoinsWallet _coinsWallet;
    [Inject] private SignalsHelper _signalsHelper;

    protected override void AddListeners()
    {
        SetAmountText(_coinsWallet.Balance());
        _signalsHelper.Subscribe<MoneySignals.Changed<Coins>>(OnAdded);
    }
    
    protected override void RemoveListeners()
    {
        _signalsHelper.Unsubscribe<MoneySignals.Changed<Coins>>(OnAdded);
    }

    private void OnAdded(MoneySignals.Changed<Coins> obj)
    {
        SetAmountText(obj.Value);
    }

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        SetAmountText(_coinsWallet.Balance());
    }

    private void SetAmountText(float amount)
    {
        var f = new NumberFormatInfo {NumberGroupSeparator = " "};
        amountText.text = amount.ToString("n0", f);
    }
}
