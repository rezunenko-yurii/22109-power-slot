using System.Linq;
using Core.Buttons;
using UnityEngine;

namespace Core.Steppers
{
    public abstract class StepperView<T> : AdvancedMonoBehaviour
    {
        [SerializeField] protected T[] items;
        [SerializeField] private int StartPosition = 0;
        [SerializeField] private AdvancedButtonUI minusButton;
        [SerializeField] private AdvancedButtonUI plusButton;
        
        protected Stepper<T> Stepper { get; set; }
        protected T Previous;
        protected T Current;

        protected override void Initialize()
        {
            base.Initialize();
            
            Stepper = new Stepper<T>(items);
            Stepper.Set(StartPosition);
            
            Current = items.First();
        }

        protected override void AddListeners()
        {
            if (minusButton != null)
            {
                minusButton.Clicked += Stepper.SetPrevious;
                plusButton.Clicked += Stepper.SetNext;
            }
            
            Stepper.Changed += OnChanged;
        }

        protected override void RemoveListeners()
        {
            if (minusButton != null)
            {
                minusButton.Clicked -= Stepper.SetPrevious;
                plusButton.Clicked -= Stepper.SetNext;
            }
            
            Stepper.Changed -= OnChanged;
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            UpdateViewData(Stepper.CurrentPosition, Stepper.CurrentValue);
        }

        protected abstract void UpdateViewData(int position, T value);

        protected virtual void OnChanged(int position, T value)
        {
            Previous = Current;
            Current = value;
            
            UpdateViewData(position, value);
        }

        public virtual void SetLast()
        {
            Stepper.SetLast();
        }
    }
}
