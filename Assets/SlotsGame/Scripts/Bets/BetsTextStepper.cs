using System.Globalization;
using Core.Steppers.TextPanels;
using Zenject;

namespace SlotsGame.Scripts.Bets
{
    public class BetsTextStepper : TextStepperValue<int>
    {
        [Inject] private BetsManager _betsManager;

        protected override void Initialize()
        {
            base.Initialize();
            _betsManager.Current = Stepper.CurrentValue;
        }

        protected override void OnChanged(int position, int value)
        {
            base.OnChanged(position, value);
            _betsManager.Current = value;
        }
        
        protected override void UpdateViewData(int position, int value)
        {
            var f = new NumberFormatInfo {NumberGroupSeparator = " "};
            textField.text  = value.ToString("n0", f);
        }
    }
}