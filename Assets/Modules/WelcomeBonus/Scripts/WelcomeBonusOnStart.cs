using Core.Popups;
using Zenject;

namespace WelcomeBonusLib
{
    public class WelcomeBonusOnStart : IPopupOnStartRequest
    {
        [Inject] private WelcomeBonus.WelcomeBonus _welcomeBonus;
        [Inject] private PopupsManager _popupsManager;
        public string popupId;
        
        public void RequestPopup()
        {
            if (!_welcomeBonus.IsTaken)
            {
                _popupsManager.Show(popupId);
            }
        }
    }
}