using StateMachine.StateCheckers;

namespace StateMachine
{
    public class MinExperienceLevelChecker : ExperienceLevelChecker
    {
        protected override bool CheckCondition() => ExperienceManager.GetCurrentLevel() >= level;
    }
}