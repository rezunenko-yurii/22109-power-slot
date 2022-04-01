using Core.Finances.Store.Products;
using UnityEngine;

namespace Finances.Store.Models
{
    public class Level : Product
    {
        public override string Type { get; protected set; } = "Level";
    }
}