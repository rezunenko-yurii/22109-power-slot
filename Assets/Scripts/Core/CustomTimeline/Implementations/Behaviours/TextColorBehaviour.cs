using System;
using TMPro;
using UnityEngine;

namespace Core.CustomTimeline.Implementations.Behaviours
{
    [Serializable]
    public class TextColorBehaviour : ColorBehaviour<TextMeshProUGUI>
    {
        protected override void SetValue(Color value)
        {
            Target.color = value;
        }
    }
}