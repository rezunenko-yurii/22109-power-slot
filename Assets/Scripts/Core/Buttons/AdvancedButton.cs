using System;
using Core.Audio;
using UnityEngine;
using Zenject;

namespace Core.Buttons
{
    public abstract class AdvancedButton : AdvancedMonoBehaviour
    {
        public event Action Clicked;
        
        [SerializeField] private bool _reactOnPauseInput = true;
        [SerializeField] private SoundName soundName;
        [Inject] private SoundsController _soundsController;
        [Inject] private SignalBus _signalBus;
        
        protected virtual void OnClick()
        {
            _soundsController.Play(soundName);
            Clicked?.Invoke();
        }
        
        private void OnUserInputResume()
        {
            ChangeInteractableState(true);
        }

        private void OnUserInputPause()
        {
            ChangeInteractableState(false);
        }
        
        protected override void AddListeners()
        {
            //Debug.Log($"{name} {nameof(AdvancedButtonUI)} {nameof(AddListeners)}");

            if (_reactOnPauseInput)
            {
                _signalBus.Subscribe<GameSignals.UserInputPause>(OnUserInputPause);
                _signalBus.Subscribe<GameSignals.UserInputResume>(OnUserInputResume);
            }
        }
        
        protected override void RemoveListeners()
        {
            //Debug.Log($"{name} {nameof(AdvancedButtonUI)} {nameof(RemoveListeners)}");

            if (_reactOnPauseInput)
            {
                _signalBus.Unsubscribe<GameSignals.UserInputPause>(OnUserInputPause);
                _signalBus.Unsubscribe<GameSignals.UserInputResume>(OnUserInputResume);
            }
        }
        
        public void SetNoClickable()
        {
            ChangeInteractableState(false);
        }
        
        public void SetClickable()
        {
            ChangeInteractableState(true);
        }
        
        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            CheckAvailability();
        }
        
        
        protected virtual void CheckAvailability() { }

        public abstract void ChangeInteractableState(bool isClickable);
    }
}