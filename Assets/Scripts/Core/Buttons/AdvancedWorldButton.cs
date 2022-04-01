using UnityEngine;

namespace Core.Buttons
{
    [RequireComponent(typeof(Collider2D))]
    
    public class AdvancedWorldButton : AdvancedButton
    {
        private bool _isClickable = true;
        private void OnMouseDown() 
        {
            if (_isClickable)
            {
                OnClick();
            }
        }

        public override void ChangeInteractableState(bool isClickable)
        {
            _isClickable = isClickable;
        }
    }
}