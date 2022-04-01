using System;
using System.Collections.Generic;
using Conditions.Models;
using UnityEngine;

namespace Conditions
{
    [Serializable]
    [CreateAssetMenu(menuName = "Conditions/ Create Conditions List")]
    public class ConditionsStepper : ScriptableObject
    {
        [field: SerializeReference, SerializeReferenceButton] public List<IChallengeModel> Items { get; private set; }

        public IChallengeModel Condition(int value)
        {
            return Items[0];
            //return Items.First(condition => condition.ContainsValue(value));
        }
    }
}