using System;
using Core.DataSavers;
using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using Modules.Reseters.Scripts;
using Modules.Tasks;
using Zenject;

namespace Modules.Challenges.Scripts
{
    public class Challenge : IChallenge
    {
        [Inject] private SignalsHelper _signalsHelper;
        [Inject] private Bundles _bundles;
        public event Action Fulfilled;
        
        public bool IsFulFilled => _dataSaver.Value;
        public string Id { get; init;}
        public string RewardId { get; init;}
        public string TaskId { get; init;}
        public ITask Task { get; set; }
        
        public string ReseterId { get; init; }
        public IReseter Reseter { get; set; }

        private BoolSaver _dataSaver;

        public bool IsStarted => !IsFulFilled && Task.CurrentAmount > 0;

        public void Init()
        {
            _dataSaver = new BoolSaver{Id = Id, DefaultValue = false};
            _dataSaver.Load();

            if (_dataSaver.Value)
            {
                return;
            }
            
            Task.StartObserving();
            Task.Started += OnTaskStarted;
            Task.Completed += OnFulfilled;
            
            Reseter.Activated += Reset;
            Reseter.StartObserving();
            Reseter.Continue();
            
            if (Task.IsStarted)
            {
                if (Reseter.CanReset())
                {
                    Reset();
                }
            }
        }

        private void OnTaskStarted()
        {
            Reseter.StartFromBeginning();
        }
        
        private void Reset()
        {
            Task.ResetProgress();
        }

        internal virtual void OnFulfilled()
        {
            _dataSaver.SetValue(true);
            
            Task.StopObserving();
            Task.Started -= OnTaskStarted;
            Task.Completed -= OnFulfilled;
            
            Reseter.StopObserving();
            Reseter.Activated -= Reset;
            
            Fulfilled?.Invoke();
            
            // TODO create event on challenge fulfilled do event notifier 
            var bundle = _bundles.GetObject(RewardId);
            _signalsHelper.Fire(typeof(Won<Bundle>), bundle);
        }
    }
}