using UnityEngine;
using UnityEngine.UI;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    [RequireComponent(typeof(Image))]
    public class ImageSpriteSwitcher : ImageSwitcher<Sprite>
    {
        protected override void ChangeValue(Sprite value)
        {
            if (value == null)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
                image.sprite = value;
            }
        }
    }
}
