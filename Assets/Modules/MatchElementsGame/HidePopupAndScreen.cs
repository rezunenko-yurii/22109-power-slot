using Core;
using Core.Buttons;
using Core.GameScreens;
using Core.Popups;
using UnityEngine;
using Zenject;

namespace MatchGame
{
    public class HidePopupAndScreen : AdvancedButtonUI
    {
        private Popup currentPopup;
        private GameScreen currentScreen;
        
        [Inject] protected PopupsManager popupsManager;
        [Inject] protected ScreensManager screensManager;
        [SerializeField] private string screenToShowId;

        protected override void OnClick()
        {
            base.OnClick();
            
            popupsManager.HideLast();
            
            currentScreen = screensManager.GetLast();
            currentScreen.Hidden += OnHidden;
            screensManager.HideLast();
        }
        
        protected virtual void OnHidden(IUIObject obj)
        {
            currentScreen.Hidden -= OnHidden;
            currentScreen = null;
            
            screensManager.Show(screenToShowId);
        }
    }
}