using System.Linq;
using Core;
using Newtonsoft.Json.Linq;

namespace MatchGame
{
    public class MatchLevels : ResourcesLoader<MatchLevel>
    {
        protected override string FolderName { get; }
        
        protected override void HandleItem(JToken jToken)
        {
            var product = MatchLevel(jToken);
            Add(product.Id, product);
        }

        private MatchLevel MatchLevel(JToken jToken)
        {
            MatchLevel matchLevel = new MatchLevel()
            {
                Id = jToken["Id"].ToString(),
                Level = (int)jToken["Level"],
                ChipsAmount = (int)jToken["ChipsAmount"],
                Time = (int)jToken["Time"]
            };

            return matchLevel;
        }
        
        public MatchLevel MatchLevel(int levelNum)
        {
            return All.FirstOrDefault(x => x.Value.Level.Equals(levelNum)).Value;
        }
    }
}