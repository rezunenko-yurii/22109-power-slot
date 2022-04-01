using System;
using Conditions;
using Conditions.Models;
using Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace ConditionsImp
{
    public class ConditionTimerText : AdvancedMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textfield;
        [SerializeField] private ChallengeModel model;

        private ConditionTimer _timer;

        protected override void Initialize()
        {
            base.Initialize();
            //_timer = _timers.All[model];
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            
            if (model.IsFulfilled)
            {
                textfield.text = "Fulfilled";
            }
            else if(model.CurrentAmount == 0)
            {
                textfield.text = "24:00:00";
            }
            else
            {
                UpdateText(_timer.ExpireTimeSpan);
            }
        }

        protected override void AddListeners()
        {
            base.AddListeners();

            if (!model.IsFulfilled)
            {
                _timer.Counting += UpdateText;
                _timer.Over += OnOver;
            }
        }

        private void OnOver()
        {
            RemoveListeners();

            if (model.IsFulfilled)
            {
                textfield.text = "Fulfilled";
            }
            else
            {
                textfield.text = "24:00:00";
            }
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            _timer.Counting -= UpdateText;
            _timer.Over -= RemoveListeners;
        }

        private void UpdateText(TimeSpan obj)
        {
            textfield.text = $"{obj.Hours:00}:" +
                             $"{obj.Minutes:00}:" +
                             $"{obj.Seconds:00}";
        }
    }
}