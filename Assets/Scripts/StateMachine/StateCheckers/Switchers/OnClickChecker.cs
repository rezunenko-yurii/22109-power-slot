using UnityEngine;
using UnityEngine.UI;

namespace StateMachine.StateCheckers.Switchers
{
    public class OnClickChecker : DualStateChecker
    {
        [SerializeField] private Button button;

        protected override void AddListeners()
        {
            base.AddListeners();
            button.onClick.AddListener(OnClicked);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            SetAllActive();
        }
    }
}