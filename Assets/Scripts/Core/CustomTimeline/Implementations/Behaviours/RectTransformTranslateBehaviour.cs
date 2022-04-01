using System;
using Core.CustomTimeline.Base;
using UnityEngine;

namespace Core.CustomTimeline.Implementations.Behaviours
{
    [Serializable]
    public class RectTransformTranslateBehaviour : Vector2Behaviour<RectTransform>
    {
        protected override void SetValue(Vector2 value)
        {
            Target.anchoredPosition = value;
        }
    }
}