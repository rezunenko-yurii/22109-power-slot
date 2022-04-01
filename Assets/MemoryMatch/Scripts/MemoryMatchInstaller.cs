using Lives;
using Modules.Dates;
using Modules.Timers.Scripts;
using UnityEngine;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class MemoryMatchInstaller : MonoInstaller
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private TextAsset _levelsConfig;
        
        public override void InstallBindings()
        {
            _signalBus.DeclareSignal<ShowAllElementsSignal>();
            _signalBus.DeclareSignal<DestroyTwoElementsSignal>();

            var matchLevels = Container.Instantiate<Levels>();
            matchLevels.Init(_levelsConfig);
            Container.Bind<Levels>().FromInstance(matchLevels).AsSingle();

            var currentLevel = Container.Instantiate<LevelsManager>();
            currentLevel.Load();
            Container.Bind<LevelsManager>().FromInstance(currentLevel).AsSingle();

            /*NextDateKeeper nextDateKeeper = new NextDateKeeper();
            nextDateKeeper.Init("Lives");
            Container.Bind<NextDateKeeper>().FromInstance(nextDateKeeper);*/
            
            MemoryTimer timer = new MemoryTimer();
            Container.Inject(timer);
            timer.Init("Lives");
            Container.Bind<MemoryTimer>().FromInstance(timer);
            //_tickableManager.AddFixed(timer);
            
            var livesManager = Container.Instantiate<LivesManager>();
            livesManager.Init(3,180, timer);
            Container.Bind<LivesManager>().FromInstance(livesManager).AsSingle();
        }
    }
}