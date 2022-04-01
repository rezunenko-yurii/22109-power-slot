using NSTools.Core;
using UnityEngine;

namespace Core.Animations
{
    public abstract class GenericAnimation<T> : BaseAnimation
    {
        [field: SerializeField] protected T StartValue { get; private set; }
        [field: SerializeField] protected T EndValue { get; private set; }
        
        protected abstract void SetValue(T value);
        protected override void SetStart() => SetValue(StartValue);
        protected override void SetEnd() => SetValue(EndValue);
        
        protected override void CreateTween()
        {
            Ez = EZ.Spawn();
            Ez.Tween(Duration, p =>
                {
                   T v = CalculateValue(p);
                   SetValue(v);
                })
                .Delay(Delay)
                .Call(OnDone);
        }

        protected virtual T CalculateValue(float progress)
        {
            var progressedValue = CalculateProgressedValue(progress);
            var progressedEase = Ease.Evaluate(progress);
            var result = CalculateFinalValue(progressedValue, progressedEase);
            
            return result;
        }

        protected abstract T CalculateProgressedValue(float progress);
        protected abstract T CalculateFinalValue(T progressedValue, float progressedEase);
    }
}