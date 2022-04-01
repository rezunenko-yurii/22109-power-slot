using System;
using System.Collections.Generic;
using Challenges;
using Conditions;
using Conditions.Models;
using Modules.Challenges.Scripts;
using UnityEngine;

namespace ConditionsImp
{
    public class Conditions
    {
        private ChallengeModel[] _models;
        
        public Dictionary<ChallengeModel, Challenge> All { get; private set; }

        public Conditions()
        {
            _models = Resources.LoadAll<ChallengeModel>("");
            Create();
        }

        private void Create()
        {
            All = new Dictionary<ChallengeModel, Challenge>();
            foreach (var model in _models)
            {
                //All.Add(model, new Challenge(model));
            }
        }
        
        public List<Challenge> ConditionByType(Type conditionType)
        {
            var products = new List<Challenge>();
            
            foreach (var product in All)
            {
                Type type = product.Key.GetType();

                if (type.Equals(conditionType))
                {
                    products.Add(product.Value);
                }
            }

            return products;
        }
    }
}