using Core;
using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using Modules.Timers.Scripts;
using UnityEngine;
using Zenject;

namespace WheelLib
{
    public class Wheels : AdvancedMonoBehaviour
    {
        [SerializeField] private Wheel[] wheels;
        
        [Inject] private SignalBus _signalBus;
        //[Inject(Id = ModuleType.Wheel)] private NextDateKeeper nextDateKeeper;
        [Inject] private Timers _timers;

        public Wheel Current { get; private set; }
        private int _currentPosition;

        private MemoryTimer _timer;


        protected override void Initialize()
        {
            base.Initialize();
            Current = wheels[_currentPosition];
            _timer = (MemoryTimer) _timers.GetObject("wheel");
        }
        

        [ContextMenu("Spin")]
        public void Spin()
        {
            Debug.Log($"{nameof(Wheels)} {nameof(Spin)}");
            
            if (Current.Spinning)
            {
                Debug.Log($"{nameof(Wheels)} {nameof(Spin)} // Wheel already spinning");
                return;
            }

            Current.Spun += OnSpun;
            Current.TrySpin();
        }

        private void OnSpun()
        {
            Debug.Log($"{nameof(Wheels)} {nameof(OnSpun)}");
            GiveReward();

            Current.Spun -= OnSpun;
            _timer.Restart();
            //nextDateKeeper.AddHoursFromNow(12);
        }

        private void GiveReward()
        {
            var sectorPosition = Current.GetSectorPosition();
            Bundle bundle = Current.SectorsRewards.Lists[sectorPosition];
            _signalBus.Fire(new Won<Bundle>(bundle));
        }
    }
}