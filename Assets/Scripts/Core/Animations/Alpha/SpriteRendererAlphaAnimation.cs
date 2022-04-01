using UnityEngine;

namespace Core.Animations.Alpha
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteRendererAlphaAnimation : GenericAnimation<Color>
    {
        [SerializeField] private SpriteRenderer image;
        protected override void Awake()
        {
            base.Awake();
            image = GetComponent<SpriteRenderer>();
        }

        protected override Color CalculateProgressedValue(float progress)
        {
            return Color.Lerp(StartValue, EndValue, progress);
        }

        protected override Color CalculateFinalValue(Color progressedValue, float progressedEase)
        {
            Color value = (EndValue - StartValue) * progressedEase + StartValue;
            return value;
        }

        protected override void SetValue(Color value)
        {
            //image.color = value;
        }
    }
}