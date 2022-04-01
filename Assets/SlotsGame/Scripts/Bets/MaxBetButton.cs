using Core.Buttons;
using UnityEngine;

namespace SlotsGame.Scripts.Bets
{
    public class MaxBetButton : AdvancedButtonUI
    {
        [SerializeField] private BetsTextStepper betsTextStepper;
        
        protected override void OnClick()
        {
            base.OnClick();
            betsTextStepper.SetLast();
        }
    }
}