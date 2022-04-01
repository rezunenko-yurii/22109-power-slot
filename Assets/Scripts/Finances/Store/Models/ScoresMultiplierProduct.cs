using Core.Finances.Store.Products;
using UnityEngine;

namespace Finances.Store.Models
{
    public class ScoresMultiplierProduct : Product
    {
        [field: SerializeField] public float Multiplier { get; private set; }
        [field: SerializeField] public int Hours { get; private set; }
        public override string Type { get; protected set; } = "ScoresMultiplier";
    }
}