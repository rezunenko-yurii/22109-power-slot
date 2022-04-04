using System;
using Modules.Reseters.Scripts;
using Modules.Tasks;

namespace Modules.Challenges.Scripts
{
    public interface IChallenge
    {
        event Action Fulfilled;

        bool IsFulFilled { get; }
        string Id { get; init; }
        string RewardId { get; init;}
        string TaskId { get; init;}
        string ReseterId { get; init;}
        bool IsStarted { get; }

        public void Init();
        
        ITask Task { get; }
        IReseter Reseter { get; }
    }
}