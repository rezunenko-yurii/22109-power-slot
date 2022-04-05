using System;
using Core.DataSavers;
using Modules.Filters.Scripts;
using UnityEngine;

namespace Modules.Tasks
{
    public abstract class ReachAmountTask : IReachAmountTask
    {
        public event Action Started;
        public event Action Completed;
        public event Action ValueChanged;
        
        public string Id { get; init; }
        public string FilterId { get; init; }
        public IFilter Filter { get; set; }
        
        public int TargetAmount { get; init; }
        public int CurrentAmount { get; private set; }
        public bool IsStarted => CurrentAmount > 0;
        
        protected IntSaver AmountSaver;
        
        public void Init()
        {
            AmountSaver = new IntSaver{Id = Id, DefaultValue = 0};
            AmountSaver.Load();

            CurrentAmount = AmountSaver.Value;
        }

        public abstract void StartObserving();
        public abstract void StopObserving();
        
        public void ResetProgress()
        {
            OnValueChanged(0);
        }

        private void OnValueChanged(int value)
        {
            CurrentAmount = value;
            AmountSaver.SetValue(CurrentAmount);
            ValueChanged?.Invoke();
        }
        
        protected void OnProgressUpdated(int value)
        {
            if (!Filter.IsRequestSatisfied())
            {
                return;
            }
            
            int clamp = Mathf.Clamp(CurrentAmount + value, 0, TargetAmount);
            TryInvokeStarted(clamp);
            OnValueChanged(clamp);
            TryInvokeCompleted();
        }

        private void TryInvokeStarted(int newValue)
        {
            if (CurrentAmount == 0 && newValue > 0)
            {
                Started?.Invoke();
            }
        }

        private void TryInvokeCompleted()
        {
            if (CurrentAmount >= TargetAmount)
            {
                Completed?.Invoke();
            }
        }
    }
}