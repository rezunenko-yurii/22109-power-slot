using System;
using Core.Finances.Store.Products;
using Core.Moneys;
using UnityEngine;

namespace Core.Finances.Moneys
{
    [Serializable]
    public abstract class Money : Product, IMoney
    {
        [field: SerializeField] public float Amount { get; set; }
        public abstract string Name { get; }
        public string FullName => $"{Name}{Sign}";
        public abstract string Sign { get; }  
    }
}