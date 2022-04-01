using Core.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    [RequireComponent(typeof(AdvancedButtonUI))]
    public class ButtonDisableSwitcher : Switcher
    {
        [SerializeField] private AdvancedButtonUI button;
        
        public override void OnTrue()
        {
            button.SetNoClickable();
        }

        public override void OnFalse()
        {
            button.SetClickable();
        }
    }
}