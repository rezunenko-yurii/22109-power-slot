using Modules.Filters.Scripts;
using Modules.Reseters.Scripts;
using Modules.Tasks;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ChallengesInstaller : MonoInstaller
    {
        [SerializeField] private TextAsset _tasksConfig;
        [SerializeField] private TextAsset _filtersConfig;
        [SerializeField] private TextAsset _resetersConfig;
        [SerializeField] private TextAsset _challengesConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<Tasks>().AsSingle().OnInstantiated<Tasks>((_, tasks) => tasks.Init(_tasksConfig)).NonLazy();
            Container.Bind<Filters>().AsSingle().OnInstantiated<Filters>((_, filters) => filters.Init(_filtersConfig)).NonLazy();
            Container.Bind<Reseters>().AsSingle().OnInstantiated<Reseters>((_, reseters) => reseters.Init(_resetersConfig)).NonLazy();
            Container.Bind<Modules.Challenges.Scripts.Challenges>().AsSingle().OnInstantiated<Modules.Challenges.Scripts.Challenges>((_, challenges) => challenges.Init(_challengesConfig)).NonLazy();
        }
    }
}