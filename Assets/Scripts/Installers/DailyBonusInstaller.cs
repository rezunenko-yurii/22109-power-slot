using DailyBonusModule;
using DailyReward;
using Modules.Dates;
using Modules.Timers.Scripts;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class DailyBonusInstaller : MonoInstaller
    {
        [field: SerializeField] private string productPacksId { get; set; }
        
        //[Inject] private TickableManager _tickableManager;
        
        private ModuleType _counterType = ModuleType.DailyBonus;
        private LastDateKeeper _dateKeeper;
        private NextDateKeeper _nextDateKeeper;
        private EveryDayCounter _everyDayCounter;
        private MemoryTimer timer;
        private DailyBonusesManager _dailyBonusesManager;
        
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(DailyBonusInstaller)} Start InstallBindings --------------");
            
            SetDateKeeper();
            SetEveryDayCounter();
            SetCountDownTimer();
            SetDailyBonusManager();
            
            Debug.Log($"{nameof(DailyBonusInstaller)} End InstallBindings --------------");
        }

        private void SetDateKeeper()
        {
            /*_dateKeeper = new LastDateKeeper(_counterType);
            Container.Bind<LastDateKeeper>().WithId(_counterType).FromInstance(_dateKeeper);
            
            _nextDateKeeper = new NextDateKeeper(_counterType);
            Container.Bind<NextDateKeeper>().WithId(_counterType).FromInstance(_nextDateKeeper);*/
        }
        
        private void SetEveryDayCounter()
        {
            _everyDayCounter = new EveryDayCounter();
            Container.Inject(_everyDayCounter);
            _everyDayCounter.Init(_counterType.ToString(),7, 2);

            Container.Bind<EveryDayCounter>().WithId(_counterType).FromInstance(_everyDayCounter);
        }

        private void SetCountDownTimer()
        {
            /*timer = new MemoryTimer();
            Container.Inject(timer);
            timer.Init(_counterType.ToString());
            
            Container.Bind<MemoryTimer>().WithId(_counterType).FromInstance(timer);*/
            //_tickableManager.AddFixed(timer);
        }

        private void SetDailyBonusManager()
        {
            _dailyBonusesManager = Container.Instantiate<DailyBonusesManager>();
            _dailyBonusesManager.Init(productPacksId);
            Container.Bind<DailyBonusesManager>().FromInstance(_dailyBonusesManager).AsSingle();
        }
    }
}