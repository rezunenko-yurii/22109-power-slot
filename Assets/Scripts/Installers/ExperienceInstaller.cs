using Boosters;
using Core.Signals.Implementation.Providers;
using Installers;
using LevelsModule;
using Modules.Dates;
using UnityEngine;
using Zenject;

namespace Bindings
{
    public class ExperienceInstaller : AdvancedMonoInstaller
    {
        [SerializeField] private TextAsset expLevelsConfig;

        private ModuleType _counterType = ModuleType.Experience;

        private NextDateKeeper _boosterDateKeeper;
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(ExperienceInstaller)} Start InstallBindings --------------");
            
            /*_boosterDateKeeper = new NextDateKeeper(_counterType);
            Container.Bind<NextDateKeeper>().WithId(_counterType).FromInstance(_boosterDateKeeper);*/
            
            Container.Bind<Scores>().AsSingle();
            
            var experienceLevels = Container.Instantiate<ExperienceLevels>();
            experienceLevels.Init(expLevelsConfig);
            Container.Bind<ExperienceLevels>().FromInstance(experienceLevels).NonLazy();
            
            var experienceManager = Container.Instantiate<ExperienceManager>();
            experienceManager.Init();
            Container.Bind<ExperienceManager>().FromInstance(experienceManager).NonLazy();
            
            Create<ExperienceLevelProvider>();
            
            Debug.Log($"{nameof(ExperienceInstaller)} Start InstallBindings --------------");
        }
    }
}