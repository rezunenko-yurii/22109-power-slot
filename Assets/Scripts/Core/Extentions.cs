using System;
using Core.Finances.Store.Products;
using GameSignals;
using Zenject;

namespace Core
{
    public static class Extentions
    {
        public static TEnum Parse<TEnum>(string value) where TEnum : struct, Enum
        { 
            return (TEnum) Enum.Parse(typeof (TEnum), value);
        }
        
        /*public static void FirePurchased<TProvider, TProduct>(this TProvider provider, TProduct product) 
            where TProvider : IProductProvider
            where TProduct : IProduct
        {
            provider.Give(product);
        }*/
        
        /*public static void FirePurchased<TProduct>(this TProduct product, SignalBus signalBus)
        {
            signalBus.AbstractFire(new Purchased<TProduct>(product));
        }*/
    }
}