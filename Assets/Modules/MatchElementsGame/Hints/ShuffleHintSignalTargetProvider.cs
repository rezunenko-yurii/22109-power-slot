using Core.Signals.Base;
using GameSignals;
using UnityEngine;

namespace MatchGame.Hints
{
    public class ShuffleHintSignalTargetProvider
    {
        protected void Activate(ShuffleHint product)
        {
            int amount = PlayerPrefs.GetInt("shuffle", 0);
            PlayerPrefs.SetInt("shuffle", amount + product.Amount);
        }
    }
}