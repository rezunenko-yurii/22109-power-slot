using UnityEngine;

public class ShowScreenButton : ScreenButton
{
    [SerializeField] private string screenToShowId;
    
    protected override void OnClick()
    {
        base.OnClick();
        ScreensManager.Show(screenToShowId);
    }
}