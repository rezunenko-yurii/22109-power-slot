using UnityEngine;

namespace Conditions.Models
{
    public class ChallengeModel : ScriptableObject, IChallengeModel
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public bool IsFulfilled { get; internal set; }
        [field: SerializeField] public int CurrentAmount { get; internal set; }
        [field: SerializeField] public int TargetAmount { get; private set; }
        [field: SerializeField] public string Rewards { get; private set; }
        [field: SerializeField] public bool IsRewardTaken { get; set; }
    }
}