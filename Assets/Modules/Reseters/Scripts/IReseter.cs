using System;

namespace Modules.Reseters.Scripts
{
    public interface IReseter
    {
        event Action Activated;
        
        string Id { get; init; }
        void Init();
        void StartObserving();
        void StopObserving();

        bool CanReset();
        void Restart();
        void StartFromBeginning();
        void Continue();
    }
}