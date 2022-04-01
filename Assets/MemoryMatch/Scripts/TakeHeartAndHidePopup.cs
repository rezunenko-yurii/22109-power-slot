using Lives;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class TakeHeartAndHidePopup : PopupHideAndShowScreen
    {
        [Inject] private LivesManager _livesManager;
        [Inject] private LevelsManager _levelsManager;
        
        protected override void OnClick()
        {
            if (_levelsManager.Current.LevelNum == _levelsManager.MaxOpened.LevelNum)
            {
                _livesManager.TryTakeLive();
            }
            base.OnClick();
        }
    }
}