using UnityEngine;

namespace Core.Animations.Translate
{
    public class LocalTranslateAnimation : VectorAnimation
    {
        protected override void SetValue(Vector2 vector2)
        {
            transform.localPosition = vector2;
        }
    }
}