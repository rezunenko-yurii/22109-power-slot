using System;
using Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace Lives
{
    public class LivesTimer : AdvancedMonoBehaviour
    {
        [Inject] private LivesManager _livesManager;
        [SerializeField] private TextMeshProUGUI _textfield;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            _livesManager.Timer.Counting += OnCounting;
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            _livesManager.Timer.Counting -= OnCounting;
        }
        
        private void OnCounting(double seconds)
        {
            OnCounting(TimeSpan.FromSeconds(seconds));
        }

        private void OnCounting(TimeSpan obj)
        {
            _textfield.text = 
                $"{obj.Hours:00}." +
                $"{obj.Minutes:00}." +
                $"{obj.Seconds:00}";
        }
    }
}