using Core.Popups.Showers;
using UnityEngine;

namespace Installers
{
    public class WatchersInstaller : AdvancedMonoInstaller
    {
        public TextAsset popupMapsConfig;
        
        public override void InstallBindings()
        {
            PopupShowerMaps popupShowerMaps = new PopupShowerMaps();
            popupShowerMaps.Init(popupMapsConfig);
            Container.Bind<PopupShowerMaps>().FromInstance(popupShowerMaps).AsSingle();
            
            PopupShower shower = Container.Instantiate<PopupShower>();
            shower.Init();
            Container.Bind<PopupShower>().FromInstance(shower).AsSingle();
        }
    }
}