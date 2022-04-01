using Core.Buttons;
using Core.Popups;
using UnityEngine;
using Zenject;

public class PopupShow : AdvancedButtonUI
{
    [Inject] protected PopupsManager popupsManager;
    [SerializeField] private string id;
    protected override void OnClick()
    {
        base.OnClick();
        popupsManager.Show(id);
    }
}