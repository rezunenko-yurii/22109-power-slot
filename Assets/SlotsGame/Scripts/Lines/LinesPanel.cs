using Core.Buttons;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.Lines
{
    public class LinesPanel : MonoBehaviour
    {
        [SerializeField] private MultiRadioButton multiRadioButton;
        [Inject] private LinesManager _linesManager;

        private void OnEnable()
        {
            multiRadioButton.CurrentButtonChanged += OnChanged;
        }
        
        private void OnDisable()
        {
            multiRadioButton.CurrentButtonChanged -= OnChanged;
        }
        
        private void OnChanged(int position, RadioButton button)
        {
            _linesManager.Count = position + 1;
        }
        
        /*private void OnEnable()
        {
            foreach (var button in buttons)
            {
                button.StateChanged += OnButtonStateChanged;
            }

            buttons[0].State = true;
        }

        private void OnButtonStateChanged(bool value, RadioButton arg2)
        {
            SetFlag(value, buttons.IndexOf(arg2));
        }

        private void SetFlag(bool value, int index)
        {
            _linesManager.LinesFlags.Set(index, value);
        }*/
    }
}