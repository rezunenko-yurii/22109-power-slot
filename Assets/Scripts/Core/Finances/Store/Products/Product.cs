using System;

namespace Core.Finances.Store.Products
{
    [Serializable]
    public abstract class Product : IProduct
    {
        public string Id { get; set; }
        public abstract string Type { get; protected set; }
        public string Description { get; set; }
    }
}