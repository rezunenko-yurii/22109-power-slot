using UnityEngine;
using UnityEngine.UI;

namespace Core.Buttons
{
    [RequireComponent(typeof(Button))]
    public class AdvancedButtonUI : AdvancedButton
    {
        protected Button Button { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Button = GetComponent<Button>();
        }
        
        public override void ChangeInteractableState(bool isClickable)
        {
            Button.interactable = isClickable;
        }
        
        protected override void AddListeners()
        {
            base.AddListeners();
            
            Button.onClick.AddListener(OnClick);
            Button.enabled = true;
        }
        
        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            Button.onClick.RemoveListener(OnClick);
            Button.enabled = false;
        }
    }
}