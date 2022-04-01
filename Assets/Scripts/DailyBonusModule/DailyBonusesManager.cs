using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using DailyReward;
using Modules.Dates;
using Modules.Timers.Scripts;
using Zenject;

namespace DailyBonusModule
{
    public class DailyBonusesManager
    {
        [Inject(Id = ModuleType.DailyBonus)] public EveryDayCounter counter;
        public MemoryTimer Timer;
        
        [Inject] private ProductBundlesSets _productBundlesSets;
        [Inject] private SignalBus _signalBus;
        [Inject] private DateKeepers _dateKeepers;
        
        public NextDateKeeper nextDateKeeper;

        public ProductBundlesSet DaysProducts { get; private set; }
        
        
        public void Init(string productPacksId)
        {
            nextDateKeeper = _dateKeepers.Get<NextDateKeeper>(ModuleType.DailyBonus.ToString());
            DaysProducts = _productBundlesSets.GetObject(productPacksId);
        }
        
        public void GiveBonus()
        {
            var products = DaysProducts.Lists[counter.CurrentDay];
            _signalBus.Fire(new Won<Bundle>(products));

            counter.Update();
            //nextDateKeeper.AddHoursFromNow(24);
        }

        public bool IsBonusAvailable()
        {
            return Timer.IsExpired;
        }
    }
}