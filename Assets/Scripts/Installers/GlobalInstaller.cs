using Core.Signals.GameSignals;
using Modules.Coroutines.Scripts;
using Modules.Dates;
using Modules.Timers.Scripts;
using UnityEngine;

namespace Installers
{
    public class GlobalInstaller : AdvancedMonoInstaller
    {
        [SerializeField] private TextAsset _timersConfig;
        public override void InstallBindings()
        {
            Container.Bind<CoroutinesManager>().FromComponentOn(gameObject).AsSingle().NonLazy();
            Container.Bind<SignalsHelper>().AsSingle().NonLazy();
            Container.Bind<DateKeepers>().AsSingle();
            Container.Bind<Timers>().AsSingle().OnInstantiated<Timers>((_, timers) => timers.Init(_timersConfig)).NonLazy();
            Create<TickManager>();
        }
    }
}