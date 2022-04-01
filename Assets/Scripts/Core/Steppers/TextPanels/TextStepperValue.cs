using System.Globalization;

namespace Core.Steppers.TextPanels
{
    public abstract class TextStepperValue<T> : TextStepper<T>
    {
        protected override void UpdateViewData(int position, T value)
        {
            textField.text  = value.ToString();
        }
    }
}