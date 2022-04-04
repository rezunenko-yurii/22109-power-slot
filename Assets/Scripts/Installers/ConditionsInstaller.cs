using Modules.Filters.Scripts;
using Modules.Reseters.Scripts;
using Modules.Tasks;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ConditionsInstaller : MonoInstaller
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
            
            /*ConditionsImp.Conditions conditions = new ConditionsImp.Conditions();
            Container.Bind<ConditionsImp.Conditions>().FromInstance(conditions).AsSingle().NonLazy();*/
            
            /*ConditionsTimers timers = Container.Instantiate<ConditionsTimers>();
            
            Dictionary<ConditionModel, ConditionTimer> All = new Dictionary<ConditionModel, ConditionTimer>();
            foreach (var model in conditions.All)
            {
                if (model.Key is ITimerRequest timerRequest)
                {
                    var nextDate = new NextDateKeeper(model.Key.Id);
                    
                    var timer = new ConditionTimer(nextDate, model.Key, model.Value);
                    timer.Init();
                    
                    Container.Bind<ConditionTimer>().FromInstance(timer).AsTransient();
                    _tickableManager.AddFixed(timer);
                    All.Add(model.Key, timer);
                    
                }
            }
            timers.Init(All);
            Container.Bind<ConditionsTimers>().FromInstance(timers).AsSingle();*/
        }
    }
}