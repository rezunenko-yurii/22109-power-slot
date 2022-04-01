using System;
using Core.Finances.Moneys;
using Finances.Moneys;
using Finances.Store.Models;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Zenject;

namespace Core.Finances.Store.Products
{
    public class Products : ResourcesLoader<Product>
    {
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var product = Product(jToken);
            Add(product.Id, product);
        }
        
        private Product Product(JToken jObject) => (string)jObject["Type"] switch
        {
            "Coins" => jObject.ToObject<Coins>(),
            "Spins" => jObject.ToObject<Spins>(),
            "ScoresMultiplier" => jObject.ToObject<ScoresMultiplierProduct>(),
            "Level" => jObject.ToObject<Level>(),
            _ => throw new ArgumentOutOfRangeException( $"Not expected direction value: {jObject}"),
        };
    }
}