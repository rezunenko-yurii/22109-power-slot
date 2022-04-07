public class ShowPreviousScreenButton : ScreenButton
{
    protected override void OnClick()
    {
        base.OnClick();
        ScreensManager.ShowPrevious();
    }
}