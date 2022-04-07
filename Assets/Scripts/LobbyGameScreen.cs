using Core.GameScreens;
using UnityEngine.Playables;
using WelcomeBonusLib;
using Zenject;

public class LobbyGameScreen : GameScreen
{ 
        [Inject] private WelcomeBonusOnStart _welcomeBonusOnStart;
        protected override void OnShown(PlayableDirector obj)
        {
                base.OnShown(obj);
                _welcomeBonusOnStart.RequestPopup();
        }
}