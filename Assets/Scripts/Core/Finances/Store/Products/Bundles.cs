using System.Collections.Generic;
using GameSignals;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Zenject;

namespace Core.Finances.Store.Products
{
    public class Bundles : ResourcesLoader<Bundle>
    {
        [Inject] private Products _products;
        protected override string FolderName { get; }
        
        protected override void HandleItem(JToken jToken)
        {
            var id = jToken["Id"].ToString();
            var productsIds = JArray.Parse(jToken["Products"].ToString());

            var listProducts = new List<IProduct>();
            foreach (var productId in productsIds)
            {
                var product = _products.GetObject(productId.ToString());
                listProducts.Add(product);
            }

            Bundle pack = new Bundle();
            pack.Init(id, listProducts);
                
            Add(id,pack);
        }
    }
}