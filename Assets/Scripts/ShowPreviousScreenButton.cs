using Core.GameScreens;
using UnityEngine;

public class ShowPreviousScreenButton : ScreenButton
{
    protected override void AddListeners()
    {
        base.AddListeners();
        ScreensManager.PreShown += OnScreenShown;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        ScreensManager.PreShown -= OnScreenShown;
    }

    private void OnScreenShown(GameScreen obj)
    {
        if (obj.Id.Equals("screen.lobby"))
        {
            Button.image.color = new Color(1,1,1,0);
        }
        else
        {
            Button.image.color = new Color(1,1,1,1);
        }
    }

    protected override void OnClick()
    {
        base.OnClick();
        ScreensManager.ShowPrevious();
    }
}