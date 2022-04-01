using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Core.GameScreens
{
    public class GameScreens : ResourcesLoader<GameScreen>
    {
        protected override string FolderName => "Screens";

        protected override void HandleItem(JToken jToken)
        {
            var id = jToken["Id"].ToString();
            var name = jToken["Name"].ToString();
            var product = Load(name);
            Add(id,product);
        }
        
        protected virtual GameScreen Load(string name)
        {
            var obj = Resources.Load<GameScreen>($"{FolderName}/{name}");
            return obj;
        }
    }
}