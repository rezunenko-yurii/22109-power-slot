using System;
using Core;
using Newtonsoft.Json.Linq;
using Zenject;

namespace Modules.Tasks
{
    public class Tasks : ResourcesLoader<ITask>
    {
        [Inject] private DiContainer _container;
        [Inject] private Filters.Scripts.Filters _filters;
        
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var task = CreateTask(jToken);
            _container.Inject(task);
            var filter = _filters.GetObject(task.FilterId);
            task.Filter = filter;
            task.Init();
            Add(task.Id, task);
        }
        
        /*"Resetter": {"Type" : "TimeFilter", "Time": 3600},
    "Filter": {"Type":"Location", "Location": "screen.game1"}*/
        
        private ITask CreateTask(JToken jObject) => (string)jObject["Type"] switch
        {
            "ReachBetsAmount" => jObject.ToObject<ReachBetsAmountTask>(),
            "ReachSpinsAmount" => jObject.ToObject<ReachSpinsAmountTask>(),
            _ => throw new ArgumentOutOfRangeException( $"Not expected direction value: {jObject}"),
        };
    }
}