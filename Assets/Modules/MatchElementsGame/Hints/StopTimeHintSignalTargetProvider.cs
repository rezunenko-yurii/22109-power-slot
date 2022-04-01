using Core.Signals.Base;
using GameSignals;
using UnityEngine;

namespace MatchGame.Hints
{
    public class StopTimeHintSignalTargetProvider
    {
        protected void Activate(StopTimeHint product)
        {
            int amount = PlayerPrefs.GetInt("stoptime", 0);
            PlayerPrefs.SetInt("stoptime", amount + product.Amount);
        }
    }
}