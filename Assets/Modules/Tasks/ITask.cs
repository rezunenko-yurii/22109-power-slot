using System;
using Modules.Filters.Scripts;

namespace Modules.Tasks
{
    public interface ITask
    {
        event Action Completed;
        event Action ValueChanged;
        public event Action Started;
        
        int TargetAmount { get; }
        int CurrentAmount { get; }
        bool IsStarted { get; }
        
        string Id { get; init; }
        string FilterId { get; init;}
        void Init();
        void StartObserving();
        void StopObserving();
        
        IFilter Filter { get; set; }
        void ResetProgress();
    }
}