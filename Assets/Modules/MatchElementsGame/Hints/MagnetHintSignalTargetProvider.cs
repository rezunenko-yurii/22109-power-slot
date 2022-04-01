using Core.Signals.Base;
using GameSignals;
using UnityEngine;

namespace MatchGame.Hints
{
    public class MagnetHintSignalTargetProvider
    {
        protected void Activate(MagnetHint product)
        {
            int amount = PlayerPrefs.GetInt("magnet", 0);
            PlayerPrefs.SetInt("magnet", amount + product.Amount);
        }
    }
}