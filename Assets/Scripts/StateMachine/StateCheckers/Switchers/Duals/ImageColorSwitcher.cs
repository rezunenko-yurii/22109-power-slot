using UnityEngine;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    public class ImageColorSwitcher : ImageSwitcher<Color>
    {
        protected override void ChangeValue(Color value)
        {
            image.color = value;
        }
    }
}