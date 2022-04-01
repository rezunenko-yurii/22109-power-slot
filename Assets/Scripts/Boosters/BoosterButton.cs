using System;
using Core.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoosterButton : AdvancedButtonUI
{
    public event Action<string> BoosterClicked;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI counter;
    
    public string Id;

    protected override void OnClick()
    {
        base.OnClick();

        int v = GetAmount - 1;
        
        if (v >= 0)
        {
            PlayerPrefs.SetInt(Id, v);
            counter.text = v.ToString();
            BoosterClicked?.Invoke(Id);
        }
    }

    public void SetData(DailyBonusItemData data)
    {
        Id = data.productId;

        image.sprite = data.sprite;
        image.SetNativeSize();

        counter.text = GetAmount.ToString();
    }
    
    private int GetAmount => PlayerPrefs.GetInt(Id, 0);
    private void SetAmount(int value) => PlayerPrefs.SetInt(Id, value);
}
