using System;
using Challenges.Tasks;
using Core.DataSavers;
using Core.Signals.GameSignals;
using Modules.Filters.Scripts;
using SlotsGame.Scripts.Bets;
using UnityEngine;
using Zenject;

namespace Modules.Tasks
{
    public class ReachBetsAmountTask : IReachAmountTask
    {
        [Inject] private SignalsHelper _signalsHelper;
        
        public event Action Completed;
        public event Action ValueChanged;

        public string Id { get; init; }
        public string FilterId { get; init; }
        public int TargetAmount { get; init; }
        public int CurrentAmount { get; private set; }
        
        private IntSaver _dataSaver;

        public void Init()
        {
            _dataSaver = new IntSaver{Id = Id, DefaultValue = 0};
            _dataSaver.Load();

            CurrentAmount = _dataSaver.Value;
        }

        public void StartObserving()
        {
            _signalsHelper.Subscribe<BetSignals.Used>(OnUsed);
        }

        public void StopObserving()
        {
            _signalsHelper.Unsubscribe<BetSignals.Used>(OnUsed);
        }

        public IFilter Filter { get; set; }

        private void OnUsed(BetSignals.Used used)
        {
            if (!Filter.IsRequestSatisfied())
            {
                return;
            }
            
            Debug.Log($"ReachBetsAmountTask {CurrentAmount} {used.Value}");
            var newValue = CurrentAmount + used.Value;
            Mathf.Clamp(newValue, 0, TargetAmount);
            CurrentAmount = newValue;
            _dataSaver.SetValue(CurrentAmount);
            
            if (CurrentAmount >= TargetAmount)
            {
                Completed?.Invoke();
            }
        }
    }
}