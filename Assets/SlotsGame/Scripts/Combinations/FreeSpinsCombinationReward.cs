using System;
using UnityEngine;

namespace SlotsGame.Scripts.Combinations
{
    [Serializable]
    [CreateAssetMenu(fileName="FreeSpinsCombinationReward", menuName = "CombinationReward/FreeSpins")]
    public class FreeSpinsCombinationReward : CombinationReward
    {
        public int amount;
    }
}