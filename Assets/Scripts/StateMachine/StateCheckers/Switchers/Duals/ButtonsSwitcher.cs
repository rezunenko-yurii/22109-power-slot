using UnityEngine;
using UnityEngine.UI;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    public class ButtonsSwitcher : Switcher
    {
        [SerializeField] private Button active;
        [SerializeField] private Button inactive;
        
        public override void OnTrue()
        {
            active.gameObject.SetActive(true);
            inactive.gameObject.SetActive(false);
        }

        public override void OnFalse()
        {
            active.gameObject.SetActive(false);
            inactive.gameObject.SetActive(true);
        }
    }
}