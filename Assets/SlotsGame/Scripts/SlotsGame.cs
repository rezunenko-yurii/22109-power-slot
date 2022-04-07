using System.Collections;
using Core;
using Core.Audio;
using Core.Signals.GameSignals;
using Finances.Wallets;
using SlotsGame.Scripts.AutoSpins;
using SlotsGame.Scripts.BoardLib;
using SlotsGame.Scripts.Combinations;
using SlotsGame.Scripts.Effects;
using SlotsGame.Scripts.Lines;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts
{
    public class SlotsGame : AdvancedMonoBehaviour
    {
        [Inject] private Board board;

        [Inject] private EffectsManager _effectsManager;
        [Inject] private CombinationHolder _combinationHolder;
        [Inject] private LinesManager _linesManager;
        [Inject] private AutoSpin _autoSpin;
        [Inject] private CombinationRewards _combinationRewards;

        [SerializeField] private AudioClip _spinSound;
        [Inject] private SoundsController _soundsController;
        
        [Inject] private SignalsHelper _signalHelper;
        [Inject] private SpinsWallet _spinsWallet;
        [Inject] private SpinPayer _spinPayer;

        private Coroutine _coroutine;
        private AudioSource _audioSource;

        private bool _isSpinning = false;
    
        protected override void Initialize()
        {
            base.Initialize();
        
            _combinationHolder.Init();
            board.Init();
            board.Appear();
        }
        
        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            _signalHelper.Fire<Core.GameSignals.UserInputResume>();

            if (HasFreeSpins())
            {
                _effectsManager.AddToQuery(EffectsTypes.FreeSpins);
                _effectsManager.Play(true);
            }
        }
        
        private bool HasFreeSpins()
        {
            var freeSpins = _spinsWallet.Balance();
            return freeSpins > 0;
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            
            board.Over += OnSpinEnded;
            _effectsManager.Completed += OnEffectsCompleted;
            _autoSpin.StateChanged += OnStateChanged;
        }
        
        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            board.Over -= OnSpinEnded;
            _effectsManager.Completed -= OnEffectsCompleted;
            _autoSpin.StateChanged -= OnStateChanged;
        }
        
        private void OnStateChanged(AutoSpinType obj)
        {
            if (!_autoSpin.Type.Equals(AutoSpinType.Off) && _spinPayer.CanPay() && !_isSpinning)
            {
                StartRound();
            }
        }
    
        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
        
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            
            board.Stop();
            _autoSpin.TransitionToForcibly(AutoSpinType.Off);
            _isSpinning = false;
            _signalHelper.Fire<Core.GameSignals.UserInputResume>();
            
            TryStopSound();
        }

        public void StartRound()
        {
            _signalHelper.Fire<Core.GameSignals.UserInputPause>();
            _isSpinning = true;

            if (HasFreeSpins())
            {
                TryStartAutoSpin();
            }
            
            Spin();
        }
        
        private void TryStartAutoSpin()
        {
            //_isSpinning = true;
            //_signalHelper.Fire<Core.GameSignals.UserInputPause>();
                
            //_effectsManager.AddToQuery(EffectsTypes.FreeSpins);
            _autoSpin.TransitSilently(AutoSpinType.ForcedAmount, (int) _spinsWallet.Balance());

            //_signalHelper.Fire<SlotSignals.EffectsStarted>();
            //_effectsManager.Play();
        }

        private void Spin()
        {
            Debug.Log($"{nameof(SlotsGame)} {nameof(Spin)}");
            
            _spinPayer.PayForSpin();
            _signalHelper.Fire<SlotSignals.SpinStarted>();
            
            _combinationHolder.Clear();
            _linesManager.Clear();
        
            _combinationHolder.Shuffle();
            board.Prepare();
            board.Play();
            
            _audioSource = _soundsController.PlayLooped(_spinSound);
        }
    
        private void OnSpinEnded()
        {
            Debug.Log($"{nameof(SlotsGame)} {nameof(OnSpinEnded)}");
            TryStopSound();
            _signalHelper.Fire<SlotSignals.SpinEnded>();

            _combinationHolder.Find();
            board.ShowCombinations();
        
            //TODO return rewards
            /*_slotMoneyHelper.GetScoresReward();
        _slotMoneyHelper.GetSpinReward();*/
        
            _combinationRewards.GetSpinReward();
        
            _signalHelper.Fire<SlotSignals.EffectsStarted>();
            _effectsManager.Play();
        }

        private IEnumerator Pause(int seconds)
        {
            Debug.Log($"{nameof(SlotsGame)} {nameof(Pause)}");
            yield return new WaitForSeconds(seconds);
        
            Debug.Log($"{nameof(SlotsGame)} {nameof(Pause)} Over");

            _signalHelper.Fire<SlotSignals.EffectsEnded>();

            if (!_autoSpin.Type.Equals(AutoSpinType.Off) && _spinPayer.CanPay())
            {
                Spin();
            }
            else
            {
                _autoSpin.TransitionTo(AutoSpinType.Off);
                _signalHelper.Fire<SlotSignals.RoundEnded>();
                _signalHelper.Fire<Core.GameSignals.UserInputResume>();
                _isSpinning = false;
            }
        }

        private void TryStopSound()
        {
            if (!ReferenceEquals(_audioSource, null))
            {
                _soundsController.StopLooped(_audioSource);
            }
        }

        private void OnEffectsCompleted()
        {
            Debug.Log($"{nameof(SlotsGame)} {nameof(OnEffectsCompleted)}");
            _coroutine = StartCoroutine(Pause(1));
        }
    }
}
