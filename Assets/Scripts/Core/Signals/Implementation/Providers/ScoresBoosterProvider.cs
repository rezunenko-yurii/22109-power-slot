using Boosters;
using Finances.Store.Models;
using Zenject;

namespace Core.Signals.Implementation.Providers
{
    public class ScoresBoosterProvider : ProductProvider<ScoresMultiplierProduct>
    {
        [Inject(Id = ModuleType.Experience)] private Booster _booster;
        
        public override void Handle(ScoresMultiplierProduct scores)
        {
            _booster.Add((int) scores.Multiplier, scores.Hours);
        }
    }
}