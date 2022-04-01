using Core.Buttons;
using Finances.Payments;
using UnityEngine;
using Zenject;

namespace Shop.Buttons
{
    public class RestorePurchasingButton : AdvancedButtonUI
    {
        [Inject] private Payments _payments;
        protected override void OnClick()
        {
            base.OnClick();
            
            Debug.Log($"{nameof(RestorePurchasingButton)} {nameof(OnClick)}");
            _payments.Restore();
        }
    }
}