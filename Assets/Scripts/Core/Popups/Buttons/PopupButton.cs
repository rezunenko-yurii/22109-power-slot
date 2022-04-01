using Core.Buttons;
using UnityEngine;
using Zenject;

namespace Core.Popups.Buttons
{
    public class PopupButton : AdvancedButtonUI
    {
        [Inject] protected PopupsManager PopupsManager;
    }
}