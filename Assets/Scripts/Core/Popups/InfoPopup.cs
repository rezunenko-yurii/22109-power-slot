using TMPro;
using UnityEngine;

namespace Core.Popups
{
    public class InfoPopup : Popup
    {
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        public void SetText(string text)
        {
            _textMeshProUGUI.text = text;
        }
    }
}