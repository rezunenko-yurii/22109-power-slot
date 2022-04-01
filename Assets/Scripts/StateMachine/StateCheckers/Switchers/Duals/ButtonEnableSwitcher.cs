using StateMachine.StateCheckers.Switchers.Duals;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachine.Common
{
    [RequireComponent(typeof(Button))]
    public class ButtonEnableSwitcher : Switcher
    {
        [SerializeField] private Button button;
        
        public override void OnTrue()
        {
            button.enabled = true;
        }

        public override void OnFalse()
        {
            button.enabled = false;
        }
    }
}