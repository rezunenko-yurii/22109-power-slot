using Core;
using Core.GameScreens;
using UnityEngine;
using Zenject;

public class PopupHideAndShowScreen : PopupHide
{
    [Inject] private ScreensManager screensManager;
    [SerializeField] private string screenId;

    private string currentScreenId;
    private GameScreen last;
    protected override void OnHidden(IUIObject obj)
    {
        base.OnHidden(obj);
        HideCurrentScreen();
    }

    private void HideCurrentScreen()
    {
        screensManager.Hidden += OnScreenHidden;
        last = screensManager.GetLast();
        screensManager.HideLast();
    }

    private void OnScreenHidden(GameScreen obj)
    {
        if (obj.Equals(last))
        {
            screensManager.Hidden -= OnScreenHidden;
            screensManager.Show(screenId);
        }
    }
}