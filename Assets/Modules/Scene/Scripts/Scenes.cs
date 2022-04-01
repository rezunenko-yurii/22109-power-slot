using Core;
using Newtonsoft.Json.Linq;

namespace UI
{
    public class Scenes : ResourcesLoader<SceneModel>
    {
        protected override string FolderName { get; }

        protected override void HandleItem(JToken jToken)
        {
            var id = jToken["Id"].ToString();
            var startScreenId = jToken["StartScreenId"].ToString();
                
            var sceneModel = new SceneModel
            {
                Id =  id,
                StartScreenId = startScreenId,
            };
                
            Add(id, sceneModel);
        }
    }
}