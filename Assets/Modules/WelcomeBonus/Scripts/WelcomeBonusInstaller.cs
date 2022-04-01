using Installers;
using UnityEngine;

namespace WelcomeBonusLib
{
    public class WelcomeBonusInstaller : AdvancedMonoInstaller
    {
        public override void InstallBindings()
        {
            if (!use)
            {
                Debug.LogWarning("Current Installer is disabled");
                return;
            }
            
            Container.Bind<WelcomeBonus.WelcomeBonus>().AsSingle().NonLazy();
            
            var welcomeBonusOnStart = Container.Instantiate<WelcomeBonusOnStart>();
            welcomeBonusOnStart.popupId = "popup.welcome";
            Container.Bind<WelcomeBonusOnStart>().FromInstance(welcomeBonusOnStart).AsSingle();
        }
    }
}