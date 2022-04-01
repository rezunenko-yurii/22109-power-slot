using Core.Buttons;
using Finances.Payments;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop.Buttons
{
    [RequireComponent(typeof(Button))]
    public class BuyProductButton : AdvancedButtonUI
    {
        [SerializeField] protected string merchandiseId;
        [Inject] protected Payments Payments;
        protected override void OnClick()
        {
            base.OnClick();
            
            Debug.Log($"{nameof(BuyProductButton)} {nameof(OnClick)}");
            Payments.Purchase(merchandiseId);
        }
    }
}
