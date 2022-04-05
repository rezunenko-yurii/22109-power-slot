using Core.Finances.Moneys;
using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using Installers;
using LevelsModule;
using Zenject;

namespace Core.Signals.Implementation.Providers
{
    public class ExperienceLevelProvider : IPreInitializable
    {
        [Inject] protected SignalsHelper SignalsHelper;
        [Inject] private Products _products;
        [Inject] private ExperienceManager _experienceManager;
        
        public void PreInitialize()
        {
            _experienceManager.Increased += OnLevelIncreased;
        }

        private void OnLevelIncreased(int obj)
        {
            Coins coins = _products.GetObject(_experienceManager.Current.ProductId) as Coins;
            SignalsHelper.Fire(typeof(Won<Coins>), coins);
        }
    }
}