using UnityEngine;

namespace Core.Animations.Translate
{
    [RequireComponent(typeof(RectTransform))]
    public class LocalRectTranslateAnimation : VectorAnimation
    {
        private RectTransform rectTransform;
        protected override void Awake()
        {
            base.Awake();
            rectTransform = GetComponent<RectTransform>();
        }
        
        protected override void SetValue(Vector2 vector2)
        {
            rectTransform.localPosition = vector2;
        }
    }
}