using Modules.Wheel.Scripts;
using UnityEngine;

namespace WheelLib
{
    public class WheelSwipeButton : BaseWheelButton
    {
        [SerializeField] private SwipeDetector swipeDetector;
        
        protected override void AddListeners()
        {
            base.AddListeners();
            swipeDetector.OnSwipeDown += Spin;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            swipeDetector.OnSwipeDown -= Spin;
        }
        

        private void Spin()
        {
            wheels.Spin();
        }
    }
}