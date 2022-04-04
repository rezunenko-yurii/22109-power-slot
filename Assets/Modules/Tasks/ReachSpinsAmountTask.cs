using System;
using Core.DataSavers;
using Core.Signals.GameSignals;
using Modules.Filters.Scripts;
using SlotsGame.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Tasks
{
    public class ReachSpinsAmountTask : ReachAmountTask
    {
        [Inject] private SignalsHelper _signalsHelper;
        
        public override void StartObserving()
        {
            _signalsHelper.Subscribe<SlotSignals.SpinStarted>(OnSpin);
        }
        
        public override void StopObserving()
        {
            _signalsHelper.Unsubscribe<SlotSignals.SpinStarted>(OnSpin);
        }
        

        private void OnSpin(SlotSignals.SpinStarted obj)
        {
            OnProgressUpdated(1);
        }
    }
}