using Core.CustomTimeline.Base;
using UnityEngine;

namespace Core.CustomTimeline.Implementations.Behaviours
{
    public abstract class ColorBehaviour<T> : GenericPlayableBehaviour<T, Color, Color> where T : class
    {
        protected override Color CalculateFinalValue(float progress, float progressedEase)
        {
            Color value = Color.Lerp(StartValue, EndValue, progress) * progressedEase;
            return value;
        }
    }
}