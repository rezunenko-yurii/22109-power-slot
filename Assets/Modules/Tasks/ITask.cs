using System;
using Modules.Filters.Scripts;

namespace Modules.Tasks
{
    public interface ITask
    {
        event Action Completed;
        event Action ValueChanged;
        
        string Id { get; init; }
        string FilterId { get; init;}
        void Init();
        void StartObserving();
        void StopObserving();
        
        IFilter Filter { get; set; }
    }
}