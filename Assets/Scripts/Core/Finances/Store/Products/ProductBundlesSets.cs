using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Zenject;

namespace Core.Finances.Store.Products
{
    public class ProductBundlesSets : ResourcesLoader<ProductBundlesSet>
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private Bundles _bundles;
        
        protected override string FolderName { get; }
        
        protected override void HandleItem(JToken jToken)
        {
            var id = jToken["Id"].ToString();
            var productsIds = JArray.Parse(jToken["Packs"].ToString());

            var productBundles = new List<Bundle>();
            foreach (var productPackId in productsIds)
            {
                var bundle = _bundles.GetObject(productPackId.ToString());
                productBundles.Add(bundle);
            }

            var productBundlesSet = new ProductBundlesSet() {Id = id, Lists = productBundles};
            Add(id, productBundlesSet);
        }
        
        /*public void Give(ProductBundlesSet productBundleSet)
        {
            foreach (var product in productBundleSet.Lists)
            {
                _productBundles.Give(product);
                
            }
        }*/
    }
}