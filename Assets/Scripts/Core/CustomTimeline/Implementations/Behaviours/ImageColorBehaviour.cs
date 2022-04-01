using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.CustomTimeline.Implementations.Behaviours
{
    [Serializable]
    public class ImageColorBehaviour : ColorBehaviour<Image>
    {
        protected override void SetValue(Color value)
        {
            Target.color = value;
        }
    }
}