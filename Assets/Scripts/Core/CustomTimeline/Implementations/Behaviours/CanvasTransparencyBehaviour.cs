using System;
using Core.CustomTimeline.Base;
using UnityEngine;

namespace Core.CustomTimeline.Implementations.Behaviours
{
    [Serializable]
    public class CanvasTransparencyBehaviour : FloatBehaviour<CanvasGroup>
    {
        protected override void SetValue(float value)
        {
            Target.alpha = value;
        }
    }
}