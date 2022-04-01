using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SlotsGame.Scripts.Combinations
{
    [Serializable]
    [CreateAssetMenu(fileName="MoneyCombinationReward", menuName = "CombinationReward/Money")]
    public class MoneyCombinationReward : CombinationReward
    {
        public List<PayoutMap> payoutMaps;

        public PayoutMap CalculateBestPayout(int chipsAmount)
        {
            var payoutMap = payoutMaps.Find(x => x.amount == chipsAmount);
            if (payoutMap == null)
            {
                int max = payoutMaps.Max(x => x.amount);
                if (chipsAmount > max)
                {
                    payoutMap = payoutMaps.Find(x => x.amount == max);
                }
            }
                
            return payoutMap;
        }
    }
}