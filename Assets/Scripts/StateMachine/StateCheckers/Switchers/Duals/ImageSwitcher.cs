using UnityEngine;
using UnityEngine.UI;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    public abstract class ImageSwitcher<T> : Switcher
    {
        [SerializeField] protected Image image;
        [SerializeField] protected T active;
        [SerializeField] protected T inactive;

        protected abstract void ChangeValue(T value);
        public override void OnTrue()
        {
            ChangeValue(active);
        }
    
        public override void OnFalse()
        {
            ChangeValue(inactive);
        }
    }
}