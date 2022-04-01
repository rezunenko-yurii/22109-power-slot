namespace Core.Steppers.TextPanels
{
    public abstract class TextStepperPosition<T> : TextStepper<T>
    {
        protected override void UpdateViewData(int position, T value)
        {
            textField.text = position.ToString();
        }
    }
}