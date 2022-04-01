using System.Collections.Generic;
using UnityEngine;

namespace Core.Finances.Store.Products
{
    public class ProductBundlesSet
    {
        public string Id { get; init; }
        public List<Bundle> Lists { get; init; }
        
        /*public void Init(string id, List<ProductBundle> productsPacks)
        {
            Id = id;
            Lists = productsPacks;
        }*/
    }
}