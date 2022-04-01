using UnityEngine;

namespace Core.CustomTimeline.Base
{
    public abstract class FloatBehaviour<T> : GenericPlayableBehaviour<T, float, float> where T : class
    {
        protected override float CalculateFinalValue(float progress, float progressedEase)
        {
            float value = Mathf.Lerp(StartValue, EndValue, progress) * progressedEase;
            return value;
        }
    }
}