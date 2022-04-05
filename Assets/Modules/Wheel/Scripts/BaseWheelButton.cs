using Core.Buttons;
using Modules.Timers.Scripts;
using UnityEngine;
using WheelLib;
using Zenject;

namespace Modules.Wheel.Scripts
{
    public class BaseWheelButton : AdvancedWorldButton
    {
        [SerializeField] protected Wheels wheels;
        [SerializeField] private bool hideOnExpire = true;
        
        [Inject] private Timers.Scripts.Timers _timers;
        private MemoryTimer _timer;

        protected override void Initialize()
        {
            base.Initialize();
            _timer = (MemoryTimer) _timers.GetObject("timer.wheel");
        }

        protected override void CheckAvailability()
        {
            ChangeInteractableState(_timer.IsExpired);

            if (hideOnExpire)
            {
                gameObject.SetActive(_timer.IsExpired);
            }
        }
        
        protected override void AddListeners()
        {
            base.AddListeners();
            
            _timer.Over += CheckAvailability;
            _timer.Started += SetNoClickable;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            _timer.Over -= CheckAvailability;
            _timer.Started -= SetNoClickable;
        }
    }
}