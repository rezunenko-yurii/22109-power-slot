using Core;
using Core.Buttons;
using Core.Popups;
using UnityEngine;
using Zenject;

public class PopupHide : AdvancedButtonUI
{
    protected Popup current;
    [Inject] protected PopupsManager popupsManager;

    protected override void OnClick()
    {
        base.OnClick();
        current = popupsManager.GetLast();
        current.Hidden += OnHidden;
        popupsManager.Hide(current);
    }

    protected virtual void OnHidden(IUIObject obj)
    {
        current.Hidden -= OnHidden;
    }
}