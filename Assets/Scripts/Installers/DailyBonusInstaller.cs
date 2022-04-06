using DailyBonusModule;
using DailyReward;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class DailyBonusInstaller : MonoInstaller
    {
        [field: SerializeField] private string productPacksId { get; set; }

        private ModuleType _counterType = ModuleType.DailyBonus;
        private EveryDayCounter _everyDayCounter;

        public override void InstallBindings()
        {
            Debug.Log($"{nameof(DailyBonusInstaller)} Start InstallBindings --------------");

            SetEveryDayCounter();
            SetDailyBonusManager();
            
            Debug.Log($"{nameof(DailyBonusInstaller)} End InstallBindings --------------");
        }
        
        
        private void SetEveryDayCounter()
        {
            _everyDayCounter = new EveryDayCounter();
            Container.Inject(_everyDayCounter);
            _everyDayCounter.Init(_counterType.ToString(),7, 2);

            Container.Bind<EveryDayCounter>().WithId(_counterType).FromInstance(_everyDayCounter);
        }

        private void SetDailyBonusManager()
        {
            var dailyBonusesManager = Container.Instantiate<DailyBonusesManager>();
            dailyBonusesManager.Init(productPacksId);
            Container.Bind<DailyBonusesManager>().FromInstance(dailyBonusesManager).AsSingle();
        }
    }
}