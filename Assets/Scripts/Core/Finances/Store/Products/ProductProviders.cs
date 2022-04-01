using System;
using System.Collections.Generic;
using Core.Finances.Moneys;
using Finances.Moneys;
using Finances.Store.Models;
using Zenject;

namespace Core.Finances.Store.Products
{
    /*public class ProductProviders
    {
        private Dictionary<Type, IProductProvider> _dictionary;
        [Inject] private DiContainer _container;

        public void Init()
        {
            _dictionary = new Dictionary<Type, IProductProvider>()
            {
                {typeof(Coins), _container.Instantiate<CoinsProvider>()},
                {typeof(LevelProduct), _container.Instantiate<LevelProductProvider>()},
                {typeof(Spins), _container.Instantiate<SpinsProvider>()},
                {typeof(ScoresMultiplierProduct), _container.Instantiate<ScoresBoosterProvider>()},
            };
        }

        public void Provide(Product product)
        {
            Type t = product.GetType();
            _dictionary[t].Give(product);
        }
    }*/
}