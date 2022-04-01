using Core.Buttons;
using Core.GameScreens;
using UnityEngine;
using Zenject;

public class ScreenButton : AdvancedButtonUI
{
    [SerializeField] private string screenToShowId;
    [Inject] private ScreensManager screensManager;

    protected override void OnClick()
    {
        base.OnClick();
        screensManager.Show(screenToShowId);
    }
}