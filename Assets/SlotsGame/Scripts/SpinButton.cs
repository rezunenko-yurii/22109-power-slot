using System;
using Core.Buttons;
using Core.Finances.Moneys;
using Core.GameScreens;
using Core.Popups;
using Finances.Moneys;
using SlotsGame.Scripts.AutoSpins;
using SlotsGame.Scripts.Bets;
using SlotsGame.Scripts.Lines;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts
{
    public class SpinButton : SignalButton
    {
        public new event Action Clicked;

        [Inject] private SlotsManager _slotsManager;
        
        /*[SerializeField] private string notEnoughCoinsPopupId;

        [Inject] private PopupsManager _popupsManager;
        [Inject] private ScreensManager _screensManager;
        
        [Inject] private SignalBus _signalBus;
        [Inject] private AutoSpin _autoSpin;
        [Inject] private BetsManager _betsManager;
        [Inject] private LinesManager _linesManager;
        
        private Spins spinPrice = new Spins {Amount = 1};
        private Coins coinsPrice = new Coins();

        public bool IsSpinning { get; private set; }*/

        /*protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            IsSpinning = false;
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            
            _autoSpin.StateChanged += AutoSpinControllerOnStateChanged;
            signalBus.Subscribe<SlotSignals.SpinStarted>(OnSpinStarted);
            signalBus.Subscribe<SlotSignals.EffectsEnded>(OnRoundEnded);
        }
        
        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            _autoSpin.StateChanged -= AutoSpinControllerOnStateChanged;
            signalBus.Unsubscribe<SlotSignals.SpinStarted>(OnSpinStarted);
            signalBus.Unsubscribe<SlotSignals.EffectsEnded>(OnRoundEnded);
        }

        private void OnRoundEnded()
        {
            Debug.Log($"{nameof(SpinButton)} Set IsSpinning = false");
            IsSpinning = false;
        }

        private void OnSpinStarted()
        {
            Debug.Log($"{nameof(SpinButton)} Set IsSpinning = true");
            IsSpinning = true;
        }

        private void AutoSpinControllerOnStateChanged(AutoSpinType obj)
        {
            if (!obj.Equals(AutoSpinType.Off) && !IsSpinning)
            {
                Spin();
            }
        }*/

        protected override void OnClick()
        {
            base.OnClick();
            _slotsManager.Spin();
        }

        /*public void Spin()
        {
            if (!IsSpinning)
            {
                if (PayForSpin())
                {
                    Clicked?.Invoke();
                }
                else
                {
                    _autoSpin.TransitionTo(AutoSpinType.Off);
                }
            }
        }*/
        
        /*public bool PayForSpin()
        {
            CalculateCoinsPrice();

            if (user.Wallets.HasOnBalance(spinPrice))
            {
                user.Wallets.Subtract(spinPrice);
                return true;
            }
            else if (user.Wallets.HasOnBalance(coinsPrice))
            {
                user.Wallets.Subtract(coinsPrice);
                _signalBus.Fire(new SpinsSignals.Spent(_screensManager.Current.Id));
                return true;
            }
            else
            {
                _popupsManager.Show(notEnoughCoinsPopupId);
                return false;
            }
        }

        public bool CanPay()
        {
            CalculateCoinsPrice();

            if (user.Wallets.HasOnBalance(spinPrice))
            {
                return true;
            }
            else if (user.Wallets.HasOnBalance(coinsPrice))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void CalculateCoinsPrice()
        {
            coinsPrice.Amount = _betsManager.Current * _linesManager.GetActiveLinesAmount();
        }*/
    }
}