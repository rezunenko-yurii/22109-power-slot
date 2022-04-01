using UnityEngine;

namespace Core.Animations.Scale
{
    public class LocalScaleAnimation : VectorAnimation
    {
        protected override void SetValue(Vector2 vector2)
        {
            transform.localScale = vector2;
        }
    }
}