using System;
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

        public void Init();
        
        ITask Task { get; }
    }
}