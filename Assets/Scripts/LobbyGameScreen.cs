using Core.GameScreens;
using UnityEngine.Playables;
using WelcomeBonusLib;
using Zenject;

public class LobbyGameScreen : GameScreen
{ 
        [Inject] private WelcomeBonusOnStart _welcomeBonusOnStart;
        protected override void OnShowed(PlayableDirector obj)
        {
                base.OnShowed(obj);
                
                _welcomeBonusOnStart.RequestPopup();
        }
}