using System;
using Core;
using Modules.Challenges.Scripts;
using Modules.Reseters.Scripts;
using Modules.Timers.Scripts;
using TMPro;
using UnityEngine;
using Zenject;

namespace ConditionsImp
{
    public class ChallengeTimerText : AdvancedMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textfield;
        [SerializeField] private string _challengeId;
        
        [Inject] private Challenges _challenges;
        
        private Challenge _challenge;
        private MemoryTimer _timer;

        protected override void Initialize()
        {
            base.Initialize();
            _challenge = _challenges.GetObject(_challengeId);
            TimerReseter reseter = (TimerReseter) _challenge.Reseter;
            
            _timer = reseter.Timer;
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();

            SetTextVariant();
        }

        private void SetTextVariant()
        {
            if (_challenge.IsFulFilled)
            {
                textfield.text = FormatSeconds(_timer.Duration);
            }
            else if (!_challenge.IsStarted || _timer.IsExpired)
            {
                textfield.text = FormatSeconds(_timer.Duration);
            }
            else
            {
                UpdateText(_timer.LeftTimeSpan());
            }
        }

        protected override void AddListeners()
        {
            base.AddListeners();

            if (!_challenge.IsFulFilled)
            {
                _timer.Counting += UpdateText;
                _timer.Over += OnOver;
            }
        }

        private void OnOver()
        {
            RemoveListeners();

            SetTextVariant();
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            _timer.Counting -= UpdateText;
            _timer.Over -= RemoveListeners;
        }
        
        private void UpdateText(double seconds)
        {
            UpdateText(TimeSpan.FromSeconds(seconds));
        }
        
        private void UpdateText(TimeSpan timeSpan)
        {
            textfield.text = FormatSeconds(timeSpan);
        }
        
        private string FormatSeconds(int seconds)
        {
            return FormatSeconds(TimeSpan.FromSeconds(seconds));
        }

        private string FormatSeconds(TimeSpan timeSpan)
        {
            return $"{GetHours(timeSpan):00}:" +
                   $"{timeSpan.Minutes:00}:" +
                   $"{timeSpan.Seconds:00}";
        }

        private int GetHours(TimeSpan timeSpan)
        {
            if (timeSpan.TotalDays > 0)
            {
                return (int) timeSpan.TotalDays * 24 + timeSpan.Hours;
            }
            else
            {
                return 0;
            }
        }
    }
}