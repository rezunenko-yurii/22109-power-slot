using Conditions.Models;
using Modules.Challenges.Scripts;
using Modules.Dates;
using Modules.Timers.Scripts;

namespace ConditionsImp
{
    public class ConditionTimer : MemoryTimer
    {
        private ChallengeModel _model;
        private Challenge _challenge;
        
        public ConditionTimer(ChallengeModel model, Challenge challenge)
        {
            _model = model;
            _challenge = challenge;

            //_challenge.ValueChanged += OnValueChanged;
            //challenge.Fulfilled += OnFulfilled;

            if (CanUse)
            {
                //_challenge.Reset();
            }
        }

        private void OnFulfilled(ChallengeModel model)
        {
            //_challenge.Fulfilled -= OnFulfilled;
            
            Stop();
            Keeper.Reset();
        }

        private void OnValueChanged()
        {
            if (CanUse)
            {
                /*var a = _model as ITimerRequest;
                Keeper.AddHoursFromNow(a.Hours);*/
            }
        }

        private bool CanUse => IsExpired && !_model.IsFulfilled && _model.CurrentAmount > 0;

        protected override void OnOver()
        {
           base.OnOver();
            if (!_model.IsFulfilled)
            {
                /*if (_model is ITimerRequest)
                {
                    _challenge.Reset();
                }*/
            }
        }
    }
}