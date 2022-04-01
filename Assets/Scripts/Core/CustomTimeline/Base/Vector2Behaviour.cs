using UnityEngine;

namespace Core.CustomTimeline.Base
{
    public abstract class Vector2Behaviour<T> : GenericPlayableBehaviour<T,Vector2,Vector2> where T : class
    {
        protected override Vector2 CalculateFinalValue(float progress, float progressedEase)
        {
            Vector2 value = Vector2.Lerp(StartValue,EndValue, progress) * progressedEase;
            return value;
        }
    }
}