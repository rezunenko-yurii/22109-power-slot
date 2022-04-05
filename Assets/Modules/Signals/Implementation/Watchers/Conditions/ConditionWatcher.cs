using Conditions;
using Conditions.Models;
using Core.Signals.Base;
using UnityEngine;
using WalletsImp;
using Zenject;

namespace Core.Signals.Implementation.Watchers.Conditions
{
    /*public abstract class ConditionWatcher<TSignal, TConditionModel> : SignalFilter<TSignal> where TConditionModel : ConditionModel where TSignal : ISignal<ISignalData>
    {
        [Inject] private ConditionsImp.Conditions _condit;
        protected TConditionModel[] models;

        public override void Init()
        {
            base.Init();
            models = Resources.LoadAll<TConditionModel>("");
        }

        protected override void OnSignalReceived(TSignal signal)
        {
            foreach (var model in models)
            {
                Condition condition = _condit.All[model];
                
                if (model.IsFulfilled) continue;
                if (!CheckLocation(signal, model)) continue;

                UseFiredObject(signal, model, condition);

                if (IsConditionMatches(signal, model))
                {
                    condition.OnFulfilled();
                }
            }
        }

        protected abstract bool IsConditionMatches(TSignal signal, TConditionModel model);

        private bool CheckLocation(TSignal signal, TConditionModel model)
        {
            if (signal is ILocationSignal locationSignal)
            {
                if (model is ILocationRequest locationRequest)
                {
                    return locationRequest.Location.Equals(locationSignal.LocationId);
                }
            }
            
            return true;
        }
        protected virtual void UseFiredObject(TSignal signal, TConditionModel model, Condition condition){} 
    }*/
}