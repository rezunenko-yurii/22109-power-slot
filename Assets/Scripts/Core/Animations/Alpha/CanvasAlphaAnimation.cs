using UnityEngine;

namespace Core.Animations.Alpha
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class CanvasAlphaAnimation : FloatAnimation
    {
        private CanvasGroup canvasGroup;

        protected override void Awake()
        {
            base.Awake();
            canvasGroup = GetComponent<CanvasGroup>();
        }
        
        protected override void SetValue(float value)
        {
            canvasGroup.alpha = value;
        }
    }
}