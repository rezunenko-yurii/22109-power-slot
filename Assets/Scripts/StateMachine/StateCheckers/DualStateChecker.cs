using StateMachine.StateCheckers.Switchers.Duals;
using UnityEngine;

namespace StateMachine
{
    public class DualStateChecker : StateChecker
    {
        [field: SerializeField] public bool Revers { get; protected set; }
        
        protected void SetAllActive()
        {
            var state = TryRevers(true);
            SetState(state);
        }
        
        protected void SetAllInactive()
        {
            var state = TryRevers(false);
            SetState(state);
        }

        private void SetState(bool state)
        {
            foreach (Switcher switcher in switchers)
            {
                if (switcher != null)
                {
                    switcher.Input(state);
                }
            }
        }

        private bool TryRevers(bool state)
        {
            if (Revers)
            {
                state = !state;
            }

            return state;
        }
    }
}