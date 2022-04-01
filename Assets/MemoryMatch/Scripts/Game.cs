using Core;
using Core.Finances.Moneys;
using Core.Finances.Wallets;
using Core.Popups;
using Lives;
using TMPro;
using UnityEngine;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class Game : AdvancedMonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private PopupsManager _popupsManager;
        [Inject] private LivesManager _livesManager;
        [Inject] private CoinsWallet _coinsWallet;
        [SerializeField] private string _winPopupId;
        [SerializeField] private string _losePopupId;
        
        [SerializeField] private Field _field;
        [SerializeField] private TimerMonoBehaviour _timer;
        [SerializeField] private TextMeshProUGUI _levelText;

        [Inject] private LevelsManager _levelsManager;

        private Coins _coins;

        protected override void AddListeners()
        {
            base.AddListeners();
            _signalBus.Subscribe<Core.GameSignals.Restart>(OnRestart);
            _signalBus.Subscribe<Core.GameSignals.Pause>(OnPause);
            _signalBus.Subscribe<Core.GameSignals.Resume>(OnResume);
            
            _signalBus.Subscribe<Core.GameSignals.NextLevel>(OnNextLevel);
            _signalBus.Subscribe<ShowAllElementsSignal>(ShowAllElements);
            _signalBus.Subscribe<DestroyTwoElementsSignal>(DestroyTwoElements);
            
            _field.Won += OnWon;
            _field.Lose += OnLose;
            _timer.Over += OnLose;
        }

        private void OnPause()
        {
            _timer.timerIsRunning = false;
        }
        
        private void OnResume()
        {
            _timer.timerIsRunning = true;
        }

        private void ShowAllElements()
        {
            _field.ShowAll();
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _signalBus.Unsubscribe<Core.GameSignals.Restart>(OnRestart);
            _signalBus.Unsubscribe<Core.GameSignals.Pause>(OnPause);
            _signalBus.Unsubscribe<Core.GameSignals.Resume>(OnResume);
            
            _signalBus.Unsubscribe<Core.GameSignals.NextLevel>(OnNextLevel);
            _signalBus.Unsubscribe<ShowAllElementsSignal>(ShowAllElements);
            _signalBus.Unsubscribe<DestroyTwoElementsSignal>(DestroyTwoElements);
            
            _field.Won -= OnWon;
            _field.Lose -= OnLose;
            _timer.Over -= OnLose;
        }

        private void DestroyTwoElements()
        {
            _field.FindMatch();
        }

        [ContextMenu("NextLevel")]
        private void OnNextLevel()
        {
            _levelsManager.TrySetNextLevelAsCurrent();
            OnRestart();
        }
        
        [ContextMenu("Restart")]
        private void OnRestart()
        {
            Debug.Log("Restart");
            Prepare();
            StartGame();
        }

        protected override void Initialize()
        {
            base.Initialize();
            
            _field.Init(_levelsManager);
            _coins = new Coins() {Amount = 100};
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            Prepare();
            StartGame();
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            _timer.Stop();
        }

        private void OnWon()
        {
            Debug.Log("Won");
            
            _timer.Stop();
            _popupsManager.Show(_winPopupId);
            _coinsWallet.Add(_coins);
        }
        
        [ContextMenu("OnLose")]
        private void OnLose()
        {
            Debug.Log("Lose");
            
            _timer.Stop();

            if (_levelsManager.Current.LevelNum == _levelsManager.MaxOpened.LevelNum)
            {
                _livesManager.TryTakeLive();
            }
            
            _popupsManager.Show(_losePopupId);
        }

        private void StartGame()
        {
            _field.StartGame();
            _timer.StartCount();
        }
        

        private void Prepare()
        {
            _field.Reset();
            _timer.Reset(_levelsManager.Current.Time);
            _levelText.text = $"Level {_levelsManager.Current.LevelNum}";
        }
    }
}