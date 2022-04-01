using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Core.Popups
{
    public class Popups : ResourcesLoader<Popup>
    {
        protected override string FolderName => "Popups";

        protected override void HandleItem(JToken jToken)
        {
            var id = jToken["Id"].ToString();
            var name = jToken["Name"].ToString();
            var product = Load(name);
            Add(id,product);
        }
        
        protected virtual Popup Load(string name)
        {
            var obj = Resources.Load<Popup>($"{FolderName}/{name}");
            return obj;
        }
    }
}