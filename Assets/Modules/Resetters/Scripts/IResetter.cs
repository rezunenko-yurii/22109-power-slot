using System;

namespace Modules.Resetters.Scripts
{
    public interface IResetter
    {
        event Action Activated;
        
        string Id { get; init; }
        void Init();
        void StopObserving();
    }
}