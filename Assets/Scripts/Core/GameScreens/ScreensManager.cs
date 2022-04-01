using Core.Popups;
using UI;
using Zenject;

namespace Core.GameScreens
{
    public class ScreensManager : UIObjectsManager<GameScreen, GameScreens>
    {
        [Inject] private PopupsManager _popupsManager;

        public GameScreen Current { get; private set; }

        private GameScreen lastScreen;
        private string _newScreenId;
        
        public override void Show(string id)
        {
            _popupsManager.TryHideLast();
            
            lastScreen = GetLast();
            if (ReferenceEquals(lastScreen, null))
            {
                base.Show(id);
            }
            else
            {
                _newScreenId = id;
                Hide(lastScreen);
            }
        }

        protected override void OnHidden(UIObject uiObject)
        {
            base.OnHidden(uiObject);
            if (!ReferenceEquals(_newScreenId, null))
            {
                base.Show(_newScreenId);
                _newScreenId = null;
            }
        }

        protected override void AddToActive(GameScreen uiObject)
        {
            base.AddToActive(uiObject);
            Current = uiObject;
        }
    }
}

