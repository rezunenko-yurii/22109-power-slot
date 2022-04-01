using UnityEngine;
using UnityEngine.UI;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    [RequireComponent(typeof(Button))]
    public class ButtonInteractableSwitcher : Switcher
    {
        [SerializeField] private Button button;
        
        public override void OnTrue()
        {
            button.interactable = true;
        }

        public override void OnFalse()
        {
            button.interactable = false;
        }
    }
}