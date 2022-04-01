using System;
using ModestTree;
using UnityEngine;

namespace Core.Buttons
{
    public class MultiRadioButton : MonoBehaviour
    {
        public event Action<int, RadioButton> CurrentButtonChanged;
        
        [SerializeField] private RadioButton[] radioButtons;
        private RadioButton _currentButton;

        private void Start()
        {
            foreach (var radioButton in radioButtons)
            {
                radioButton.StateChanged += OnButtonClicked;
            }

            _currentButton = radioButtons[0];
            _currentButton.ChangeState(true, false);
        }

        private void OnButtonClicked(bool value, RadioButton button)
        {
            if (!value)
            {
                return;
            }
            
            _currentButton = button;

            foreach (var radioButton in radioButtons)
            {
                if (radioButton != _currentButton)
                {
                    _currentButton.ChangeState(false, true);
                }
            }
            
            CurrentButtonChanged?.Invoke(GetCurrentButtonPosition, _currentButton);
        }

        public RadioButton GetCurrentButton => _currentButton;
        public int GetCurrentButtonPosition => radioButtons.IndexOf(_currentButton);
    }
}