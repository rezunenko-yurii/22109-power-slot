using Core;
using UnityEngine;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    public abstract class Switcher : AdvancedMonoBehaviour
    {
        public abstract void OnTrue();
        public abstract void OnFalse();

        [field: SerializeField] public bool Revers { get; protected set; }

        public void Input(bool state)
        {
            if (Revers)
            {
                state = !state;
            }
            
            if (state)
            {
                OnTrue();
            }
            else
            {
                OnFalse();
            }
        }
    }
}