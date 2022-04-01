using Core.Finances.Store;
using Core.Finances.Store.Products;
using Core.Popups.Showers;
using Core.Signals.Base;
using Core.Signals.GameSignals;
using Core.Signals.Implementation.Watchers.Conditions;
using DefaultNamespace;
using GameSignals;
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
            
            BetConditionWatcher betConditionWatcher = Container.Instantiate<BetConditionWatcher>();
            //betConditionWatcher.Init();
            Container.Bind<BetConditionWatcher>().FromInstance(betConditionWatcher).AsSingle();
            
            /*ExperienceConditionWatcher experienceConditionWatcher = Container.Instantiate<ExperienceConditionWatcher>();
            experienceConditionWatcher.Init();
            Container.Bind<ExperienceConditionWatcher>().FromInstance(experienceConditionWatcher).AsSingle();*/
            
            SpinsConditionWatcher spinsConditionWatcher = Container.Instantiate<SpinsConditionWatcher>();
            //spinsConditionWatcher.Init();
            Container.Bind<SpinsConditionWatcher>().FromInstance(spinsConditionWatcher).AsSingle();
            
            //Container.BindInterfacesAndSelfTo<EventNotifier<PurchaseFailed<Merchandise>, Merchandise>>().AsSingle().NonLazy();
            //Container.BindInterfacesAndSelfTo<EventNotifier<PurchaseFailed<Bundle>,Bundle>>().AsSingle().NonLazy();

            PopupShower shower = Container.Instantiate<PopupShower>();
            shower.Init();
            Container.Bind<PopupShower>().FromInstance(shower).AsSingle();
            
        }
    }
}