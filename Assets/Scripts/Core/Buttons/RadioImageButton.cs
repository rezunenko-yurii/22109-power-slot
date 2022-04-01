using UnityEngine;
using UnityEngine.UI;

namespace Core.Buttons
{
    public class RadioImageButton : RadioButton
    {
        [SerializeField] private Image image;
        [SerializeField] private Sprite on;
        [SerializeField] private Sprite off;
        
        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            UpdateImageState();
        }

        protected override void OnStateChanged()
        {
            base.OnStateChanged();
            UpdateImageState();
        }

        protected virtual void UpdateImageState()
        {
            image.sprite = State switch
            {
                true => on,
                false => off,
            };
        }

        protected virtual void UpdateImageState(bool state)
        {
            image.sprite = state switch
            {
                true => on,
                false => off,
            };
        }
    }
}