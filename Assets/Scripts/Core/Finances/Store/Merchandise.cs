using Core.Finances.Moneys;
using Core.Finances.Store.Products;
using Core.Signals;
using Core.Signals.Base;
using UnityEngine.Purchasing;

namespace Core.Finances.Store
{
    public class Merchandise : IIdentifier
    {
        public string Id { get; init; }
        public string Type { get; init; }
        public Money Price { get; init; }
        public ProductType ProductType { get; init; }
        public Bundle Bundle { get; init; }
        public string ResultInfo;
        
        public Merchandise(){}
    }
}