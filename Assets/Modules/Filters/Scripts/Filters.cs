using System;
using Core;
using Newtonsoft.Json.Linq;
using Zenject;

namespace Modules.Filters.Scripts
{
    public class Filters : ResourcesLoader<IFilter>
    {
        [Inject] private DiContainer _container;
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var filter = CreateFilter(jToken);
            _container.Inject(filter);
            Add(filter.Id, filter);
        }
        
        private IFilter CreateFilter(JToken jToken) => (string)jToken["Type"] switch
        {
            "ScreensFilter" => jToken.ToObject<ScreensFilter>(),
            _ => throw new ArgumentOutOfRangeException( $"Not expected direction value: {jToken}"),
        };
    }
}