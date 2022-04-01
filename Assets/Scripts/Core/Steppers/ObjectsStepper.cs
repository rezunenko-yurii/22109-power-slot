using UnityEngine;

namespace Core.Steppers
{
    public class ObjectsStepper : StepperView<GameObject>
    {
        protected override void UpdateViewData(int position, GameObject value)
        {
            if (Previous != null)
            {
                Previous.SetActive(false);
            }
            
            Current.SetActive(true);
        }
    }
}