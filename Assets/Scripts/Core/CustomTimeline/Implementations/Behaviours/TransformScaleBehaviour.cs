using System;
using Core.CustomTimeline.Base;
using UnityEngine;

namespace Core.CustomTimeline.Implementations.Behaviours
{
    [Serializable]
    public class TransformScaleBehaviour : Vector2Behaviour<Transform>
    {
        protected override void SetValue(Vector2 value)
        {
            Target.localScale = value;
        }
    }
}