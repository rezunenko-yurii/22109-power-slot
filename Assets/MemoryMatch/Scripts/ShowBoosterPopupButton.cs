using Core.Popups.Buttons;
using UnityEngine;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class ShowBoosterPopupButton<T> : ShowPopupButton
    {
        [Inject] private SignalBus _signalBus;

        protected override void OnClick()
        {
            string key = typeof(T).Name;
            int isTestUsed = PlayerPrefs.GetInt(key, 0);
            if (isTestUsed == 0)
            {
                PlayerPrefs.SetInt(key, 1);
                _signalBus.Fire<T>();
            }
            else
            {
                base.OnClick();
            }
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            SetNoClickable();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            _signalBus.Subscribe<Core.GameSignals.UserInputPause>(OnPause);
            _signalBus.Subscribe<Core.GameSignals.UserInputResume>(OnResume);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _signalBus.Unsubscribe<Core.GameSignals.UserInputPause>(OnPause);
            _signalBus.Unsubscribe<Core.GameSignals.UserInputResume>(OnResume);
        }

        private void OnResume()
        {
            SetClickable();
        }

        private void OnPause()
        {
            SetNoClickable();
        }
    }
}