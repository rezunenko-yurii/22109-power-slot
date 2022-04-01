using UnityEngine;

namespace Core.Popups.Buttons
{
    public class HidePopupButton : PopupButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            
            Debug.Log($"{nameof(HidePopupButton)} {nameof(OnClick)}");
            PopupsManager.HideLast();
        }
    }
}
    