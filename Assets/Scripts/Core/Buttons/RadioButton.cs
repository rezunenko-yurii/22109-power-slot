using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Buttons
{
    [RequireComponent(typeof(Button))]
    public class RadioButton : AdvancedButtonUI
    {
        public event Action<bool, RadioButton> StateChanged;
        public event Action<bool, RadioButton> StateChangedByClick;
        [SerializeField] private bool currentState = false;
    
        public virtual bool State
        {
            get => currentState;
            /*set
            {
                if (currentState != value)
                {
                    currentState = value;
                    OnStateChanged();
                }
            }*/
        }

        public virtual void ChangeStateSilently(bool newState)
        {
            currentState = newState;
        }

        public virtual void ChangeState(bool newState, bool changedByClick)
        {
            if (currentState != newState)
            {
                currentState = newState;
                
                OnStateChanged();
                
                if (changedByClick)
                {
                    OnStateChangedByClick();
                }
            }
        }
        
        protected virtual void OnStateChanged()
        {
            StateChanged?.Invoke(currentState, this);
        }
        
        protected virtual void OnStateChangedByClick()
        {
            StateChangedByClick?.Invoke(currentState, this);
        }

        protected override void OnClick()
        {
            if (CanChangeState())
            {
                ChangeState(!currentState, true);
                base.OnClick();
            }
        }

        protected virtual bool CanChangeState()
        {
            return true;
        }
    }
}
