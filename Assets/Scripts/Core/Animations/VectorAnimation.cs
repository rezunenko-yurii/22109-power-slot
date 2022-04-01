using UnityEngine;

namespace Core.Animations
{
    public abstract class VectorAnimation : GenericAnimation<Vector2>
    {
        protected override Vector2 CalculateProgressedValue(float progress)
        {
            Vector2 value = Vector2.Lerp(StartValue,EndValue, progress);
            return value;
        }

        protected override Vector2 CalculateFinalValue(Vector2 progressedValue, float progressedEase)
        {
            Vector2 value = (EndValue - StartValue) * progressedEase + StartValue;
            Debug.Log($"{GetType()} {nameof(CalculateFinalValue)} value={value} | progressedValue={progressedValue} ease={progressedEase}");
            return value;
        }
    }
}