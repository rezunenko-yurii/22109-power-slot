using Core.Steppers.TextPanels;
using Zenject;

namespace SlotsGame.Scripts.Lines
{
    public class LinesTextStepper : TextStepperValue<int>
    {
        [Inject] private LinesManager _linesManager;
        
        protected override void Initialize()
        {
            base.Initialize();
            _linesManager.Count = Stepper.CurrentPosition;
        }

        protected override void OnChanged(int position, int value)
        {
            base.OnChanged(position, value);
            _linesManager.Count = position;
        }
    }
}