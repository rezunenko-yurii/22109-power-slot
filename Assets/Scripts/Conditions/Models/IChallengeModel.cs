namespace Conditions.Models
{
    public interface IChallengeModel
    {
        string Id { get; }
        bool IsFulfilled { get; }
        string Rewards { get; }
        
        
        int CurrentAmount { get; }
        int TargetAmount { get; }
        
    }
}