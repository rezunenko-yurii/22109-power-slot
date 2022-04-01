using Core.Finances.Store.Products;
using UnityEngine;

namespace MatchGame.Hints
{
    public class Hint : Product
    {
        [field: SerializeField] public int Amount { get; set; }
        public override string Type { get; protected set; }
    }
}