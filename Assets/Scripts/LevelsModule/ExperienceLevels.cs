using Core;
using Newtonsoft.Json.Linq;

namespace LevelsModule
{
    public class ExperienceLevels : ResourcesLoader<ExperienceLevel>
    {
        protected override string FolderName { get; }
        
        protected override void HandleItem(JToken jToken)
        {
            var level = jToken.ToObject<ExperienceLevel>();
            Add(level.Level.ToString(), level);
        }
    }
}