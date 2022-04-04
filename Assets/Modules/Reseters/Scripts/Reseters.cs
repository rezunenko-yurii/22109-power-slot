using System;
using Core;
using Newtonsoft.Json.Linq;
using Zenject;

namespace Modules.Reseters.Scripts
{
    public class Reseters : ResourcesLoader<IReseter>
    {
        [Inject] private DiContainer _container;
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var resetter = Create(jToken);
            _container.Inject(resetter);
            resetter.Init();
            
            Add(resetter.Id, resetter);
        }
        
        private IReseter Create(JToken jToken) => (string)jToken["Type"] switch
        {
            "TimerReseter" => jToken.ToObject<TimerReseter>(),
            _ => throw new ArgumentOutOfRangeException( $"Not expected direction value: {jToken}"),
        };
    }
}