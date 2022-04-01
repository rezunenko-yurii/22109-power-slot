using UnityEngine;
using UnityEngine.UI;

namespace Core.Animations.Alpha
{
    [RequireComponent(typeof(Image))]
    public class ImageAlphaAnimation : GenericAnimation<Color>
    {
        [SerializeField] private Image image;
        protected override void Awake()
        {
            base.Awake();
            image = GetComponent<Image>();
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
            image.color = value;
        }
    }
}