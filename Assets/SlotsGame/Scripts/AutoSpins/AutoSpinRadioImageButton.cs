using Core.Buttons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SlotsGame.Scripts.AutoSpins
{
    [RequireComponent(typeof(Button))]
    public class AutoSpinRadioImageButton : RadioImageButton
    {
        [Inject] private AutoSpin _autoSpin;
        [Inject] private SpinPayer _spinPayer;

        private void AutoSpinControllerOnStateChanged(AutoSpinType type)
        {
            var newState = !type.Equals(AutoSpinType.Off);
            ChangeState(newState, false);
            
            bool isClickable = !type.Equals(AutoSpinType.ForcedAmount);
            ChangeInteractableState(isClickable);
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            ChangeStateSilently(!_autoSpin.Type.Equals(AutoSpinType.Off));
            UpdateImageState();
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
        
            //_autoSpin.TransitSilently(AutoSpinType.Off);
            //ChangeStateSilently(false);
            //UpdateImageState();
        }

        protected override bool CanChangeState()
        {
            return _spinPayer.CanPay();
        }

        protected override void OnStateChangedByClick()
        {
            base.OnStateChangedByClick();
            _autoSpin.TransitionTo(State ? AutoSpinType.Infinity : AutoSpinType.Off);
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            _autoSpin.StateChanged += AutoSpinControllerOnStateChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _autoSpin.StateChanged -= AutoSpinControllerOnStateChanged;
        }
    }
}
