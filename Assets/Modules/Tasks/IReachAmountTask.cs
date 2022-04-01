using Modules.Tasks;

namespace Challenges.Tasks
{
    public interface IReachAmountTask : ITask
    {
        int TargetAmount { get; }
        int CurrentAmount { get; }
    }
}