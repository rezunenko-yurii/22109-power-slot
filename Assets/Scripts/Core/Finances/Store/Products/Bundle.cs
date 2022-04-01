using System.Collections.Generic;
using Core.Signals;
using Core.Signals.Base;

namespace Core.Finances.Store.Products
{
    public class Bundle : IIdentifier
    {
        public string Id { get; private set; }
        public string Type  => "Bundle";
        public List<IProduct> Products { get; private set; }

        public void Init(string id, List<IProduct> products)
        {
            Id = id;
            Products = products;
        }
    }
}