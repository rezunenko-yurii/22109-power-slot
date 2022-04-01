using Core;
using GameCores.MemoryMatchGame;
using Newtonsoft.Json.Linq;

namespace MemoryMatch.Scripts
{
    public class Levels : ResourcesLoader<Level>
    {
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var level = jToken.ToObject<Level>();
            Add(level.Id, level);
        }
    }
}