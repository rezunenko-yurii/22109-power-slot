using UnityEngine;
using UnityEngine.UI;

namespace Core.Steppers
{
    public class ImageStepper : StepperView<Sprite>
    {
        [SerializeField] private Image _image;

        protected override void UpdateViewData(int position, Sprite value)
        {
            _image.sprite = value;
            _image.SetNativeSize();
        }
    }
}