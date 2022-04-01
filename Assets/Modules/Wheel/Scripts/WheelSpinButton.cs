using UnityEngine;

namespace Modules.Wheel.Scripts
{
    public class WheelSpinButton : BaseWheelButton
    {
        protected override void OnClick()
        {
            Debug.Log($"{nameof(WheelSpinButton)} {nameof(OnClick)}");
            
            wheels.Spin();
            //Button.gameObject.SetActive(false);
            base.OnClick();
        }
    }
}
