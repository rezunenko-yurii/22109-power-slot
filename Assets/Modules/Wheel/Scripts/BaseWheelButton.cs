using Core.Buttons;
using Modules.Timers.Scripts;
using UnityEngine;
using WheelLib;
using Zenject;

namespace Modules.Wheel.Scripts
{
    public class BaseWheelButton : AdvancedWorldButton
    {
        [Inject(Id = ModuleType.Wheel)] private MemoryTimer timer;
        [SerializeField] protected Wheels wheels;
        [SerializeField] private bool hideOnExpire = true;
        
        protected override void CheckAvailability()
        {
            ChangeInteractableState(timer.IsExpired);

            if (hideOnExpire)
            {
                gameObject.SetActive(timer.IsExpired);
            }
        }
        
        protected override void AddListeners()
        {
            base.AddListeners();
            
            timer.Over += CheckAvailability;
            timer.Started += SetNoClickable;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            timer.Over -= CheckAvailability;
            timer.Started -= SetNoClickable;
        }
    }
}