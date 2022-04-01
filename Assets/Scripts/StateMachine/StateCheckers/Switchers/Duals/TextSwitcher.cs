using StateMachine.StateCheckers.Switchers.Duals;
using TMPro;
using UnityEngine;

namespace StateMachine.Common
{
    public class TextSwitcher : Switcher
    {
        [SerializeField] private TextMeshProUGUI _textfield;
    
        [SerializeField] private string activeText;
        [SerializeField] private Color activeColor;
    
        [SerializeField] private string inactiveText;
        [SerializeField] private Color inactiveColor;
    
        private void Awake()
        {
            if (_textfield == null)
            {
                _textfield = transform.GetComponent<TextMeshProUGUI>();
            }
        }
        
        public override void OnTrue()
        {
            SetText(activeText, activeColor);
        }

        public override void OnFalse()
        {
            SetText(inactiveText, inactiveColor);
        }

        private void SetText(string text, Color color)
        {
            if (string.IsNullOrEmpty(text))
            {
                _textfield.enabled = false;
            }
            else
            {
                _textfield.enabled = true;
                _textfield.text = text;
                _textfield.color = color;
            }
        }
    }
}
