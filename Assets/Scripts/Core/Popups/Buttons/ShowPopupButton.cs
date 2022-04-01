using UnityEngine;

namespace Core.Popups.Buttons
{
    public class ShowPopupButton : PopupButton
    {
        [SerializeField] private string popupId;
        [SerializeField] private bool hideOnClick;
        protected override void OnClick()
        {
            base.OnClick();

            if (hideOnClick)
            {
                PopupsManager.HideLast();
            }
            
            Debug.Log($"{nameof(ShowPopupButton)} {nameof(OnClick)}");
            PopupsManager.Show(popupId);
        }
    }
}
