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
        //[SerializeField] private AudioClip _music;
        //[SerializeField] private SpinButton spinButton;
    
        [Inject] private EffectsManager _effectsManager;
        [Inject] private CombinationHolder _combinationHolder;
        [Inject] private LinesManager _linesManager;
        [Inject] private AutoSpin _autoSpin;
        [Inject] private CombinationRewards _combinationRewards;

        [SerializeField] private AudioClip _spinSound;
        [Inject] private SoundsController _soundsController;
        
        [Inject] private SignalsHelper _signalHelper;
        [Inject] private SpinsWallet _spinsWallet;

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
            TryStartAutoSpin();
        }

        private void TryStartAutoSpin()
        {
            var freeSpins = _spinsWallet.Balance();
            if (freeSpins > 0)
            {
                _effectsManager.AddToQuery(EffectsTypes.FreeSpins);
                _autoSpin.TransitionTo(AutoSpinType.ForcedAmount, (int) freeSpins);

                _signalHelper.Fire<SlotSignals.EffectsStarted>();
                _effectsManager.Play();
            }
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            
            board.Over += OnSpinEnded;
            _effectsManager.Completed += OnEffectsCompleted;
        }
    
        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            board.Over -= OnSpinEnded;
            _effectsManager.Completed -= OnEffectsCompleted;
        }
    
        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
        
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                board.Stop();
            }
            
            TryStopSound();
        }

        public void StartRound()
        {
            _signalHelper.Fire<Core.GameSignals.UserInputPause>();
            Spin();
        }

        private void Spin()
        {
            Debug.Log($"{nameof(SlotsGame)} {nameof(Spin)}");
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
            TryStopSound();
            yield return new WaitForSeconds(seconds);
        
            Debug.Log($"{nameof(SlotsGame)} {nameof(Pause)} Over");

            _signalHelper.Fire<SlotSignals.EffectsEnded>();

            if (!_autoSpin.Type.Equals(AutoSpinType.Off))
            {
                Spin();
            }
            else
            {
                _signalHelper.Fire<SlotSignals.RoundEnded>();
                _signalHelper.Fire<Core.GameSignals.UserInputResume>();
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
