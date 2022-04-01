using System;
using Core;
using Newtonsoft.Json.Linq;
using Zenject;

namespace Modules.Timers.Scripts
{
    public class Timers : ResourcesLoader<Timer>
    {
        [Inject] private DiContainer _container;
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var timer = Create(jToken);
            _container.Inject(timer);
            timer.Init();
            Add(timer.Id, timer);
        }
        
        private Timer Create(JToken jToken) => (string)jToken["Type"] switch
        {
            "Timer" => jToken.ToObject<Timer>(),
            "MemoryTimer" => jToken.ToObject<MemoryTimer>(),
            _ => throw new ArgumentOutOfRangeException( $"Not expected direction value: {jToken}"),
        };
    }
}