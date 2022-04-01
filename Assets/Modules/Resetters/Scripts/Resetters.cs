using System;
using Core;
using Newtonsoft.Json.Linq;
using Zenject;

namespace Modules.Resetters.Scripts
{
    public class Resetters : ResourcesLoader<IResetter>
    {
        [Inject] private DiContainer _container;
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var resetter = CreateResetter(jToken);
            _container.Inject(resetter);
            Add(resetter.Id, resetter);
        }
        
        private IResetter CreateResetter(JToken jToken) => (string)jToken["Type"] switch
        {
            _ => throw new ArgumentOutOfRangeException( $"Not expected direction value: {jToken}"),
        };
    }
}