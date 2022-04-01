using Newtonsoft.Json.Linq;

namespace Core.Popups.Showers
{
    public class PopupShowerMaps : ResourcesLoader<PopupShowerMap>
    {
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var map = jToken.ToObject<PopupShowerMap>();
            Add(map.Id, map);
        }
    }
}