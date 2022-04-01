using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using LevelsModule;
using Zenject;

namespace Core.Popups
{
    public class ExperienceLevelIncreasedPopup : InfoPopup
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private Products _products;
        [Inject] private ExperienceManager _experienceManager;
        
        public override void HandleSignal(IGameSignal gameSignal)
        {
            /*base.HandleSignal(gameSignal);
            if (gameSignal is ExperienceSignals.Increased increased)
            {
                var product =_products.GetObject(increased.Value.ProductId);
                SetText(product.Description);
            }*/
        }
    }
}