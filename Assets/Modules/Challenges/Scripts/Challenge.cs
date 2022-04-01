using System;
using Core.DataSavers;
using Modules.Filters.Scripts;
using Modules.Tasks;

namespace Modules.Challenges.Scripts
{
    public class Challenge : IChallenge
    {
        public event Action Fulfilled;

        public bool IsFulFilled { get; }
        public string Id { get; init;}
        public string RewardId { get; init;}
        public string TaskId { get; init;}
        public string FilterId { get; }

        public ITask Task { get; set; }
        public IFilter Filter { get; set; }
        
        private BoolSaver _dataSaver;
        
        public void Init()
        {
            _dataSaver = new BoolSaver(){Id = Id, DefaultValue = false};
            _dataSaver.Load();

            if (!_dataSaver.Value)
            {
                Task.StartObserving();
                Task.Completed += OnFulfilled;
            }
        }

        internal virtual void OnFulfilled()
        {
            _dataSaver.SetValue(true);
            Task.StopObserving();
            Fulfilled?.Invoke();
        }
    }
}