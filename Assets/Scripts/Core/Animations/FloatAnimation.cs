using UnityEngine;

namespace Core.Animations
{
    public abstract class FloatAnimation : GenericAnimation<float>
    {
        protected override float CalculateProgressedValue(float progress)
        {
            return Mathf.Lerp(StartValue,EndValue, progress);
        }

        protected override float CalculateFinalValue(float progressedValue, float progressedEase)
        {
            var value = (EndValue - StartValue) * progressedEase + StartValue;
            return value;
        }
    }
}