using Core.Signals.GameSignals;
using Finances.Store.Models;
using UnityEngine;

namespace Core.Signals.Implementation.Providers
{
    public class LevelProvider : ProductProvider<Level>
    {
        public override void Handle(Level level)
        {
            PlayerPrefs.SetString(level.Id, level.Id);
            SignalsHelper.Fire(typeof(Taken<Level>), level);
        }
    }
}