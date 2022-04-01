using Core.Signals.Base;
using GameSignals;
using UnityEngine;

namespace MatchGame.Hints
{
    public class ExtraTimeHintSignalTargetProvider
    {
        protected void Activate(ExtraTimeHint product)
        {
            int amount = PlayerPrefs.GetInt("extratime", 0);
            PlayerPrefs.SetInt("extratime", amount + product.Amount);
        }
    }
}