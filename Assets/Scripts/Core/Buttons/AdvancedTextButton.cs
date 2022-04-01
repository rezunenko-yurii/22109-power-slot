using TMPro;
using UnityEngine;

namespace Core.Buttons
{
    public class AdvancedTextButton : AdvancedButtonUI
    {
        [SerializeField] protected TextMeshProUGUI textfield;
        [SerializeField] protected bool canChangeText = true;
        
        public void SetText(string text)
        {
            textfield.text = text;
        }
    }
}