using Core.Finances.Moneys;
using Core.Finances.Store.Products;
using Core.Popups;
using Core.Signals.GameSignals;
using GameSignals;
using SlotsGame.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DoubleGameLib
{
    public class DoubleGame : MonoBehaviour
    {
        [SerializeField] private Button redButton;
        [SerializeField] private Button blueButton;

        [SerializeField] private DoubleGameResult hiddenCard;
        [SerializeField] private DoubleGameHistory history;
        
        [SerializeField] private TextMeshProUGUI currentWinText;
        [SerializeField] private TextMeshProUGUI toWinText;
        [SerializeField] private TextMeshProUGUI attemptsText;
        
        //[Inject] private GameScreensManager _gameScreensManager;
        [Inject] private PopupsManager _popupsManager;
        [Inject] private RoundCoinsWonWatcher roundCoinsWonWatcher;
        [Inject] private SignalBus _signalBus;

        //[Inject] private ProductsProviders _providers;
        [Inject] private Products _products;

        //private int currentSum;
        private int attempt;
        private const int maxAttempts = 5;
        
        private DoubleCardType _clickedType;

        private string doubleAmount = "TOTAL WIN:";
        private string doubleAmountToWin = "NEXT WIN:";
        private string doubleAttemptsLeft = "USED:";
        
        private void UpdateTexts()
        {
            currentWinText.text = doubleAmount + roundCoinsWonWatcher.Amount * attempt;
            toWinText.text = doubleAmountToWin + roundCoinsWonWatcher.Amount * (attempt + 1);
            //attemptsText.text = doubleAttemptsLeft + (maxAttempts - attempt);
            attemptsText.text = $"{doubleAttemptsLeft} {attempt}/{maxAttempts}";
        }

        private void OnEnable()
        {
            AddListeners();

            Reset();
            UpdateTexts();
        }

        private void AddListeners()
        {
            redButton.onClick.AddListener(OnRedButtonClicked);
            blueButton.onClick.AddListener(OnBlueButtonClicked);
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void RemoveListeners()
        {
            redButton.onClick.RemoveListener(OnRedButtonClicked);
            blueButton.onClick.RemoveListener(OnBlueButtonClicked);
        }

        private void OnBlueButtonClicked()
        {
            OnClicked(DoubleCardType.Blue);
        }

        private void OnRedButtonClicked()
        {
            OnClicked(DoubleCardType.Red);
        }

        private void OnClicked(DoubleCardType clickedType)
        {
            _clickedType = clickedType;
            RemoveListeners();
            
            hiddenCard.Apply(ApplyResult);
        }

        private void ApplyResult()
        {
            history.Add(hiddenCard.CardType, attempt);

            if (_clickedType.Equals(hiddenCard.CardType))
            {
                Win();
            }
            else
            {
                GameOver();
            }
            
            UpdateTexts();
            AddListeners();
        }

        private void Win()
        {
            attempt++;
            if (attempt == maxAttempts)
            {
                GiveReward();
                GameOver();
            }
            else
            {
                //currentSum *= 2;
                //hiddenCard.SetNewType();
            }
        }
        

        private void GameOver()
        {
            GoBackToPreviousScreen();
        }

        private void GoBackToPreviousScreen()
        {
            //_gameScreensManager.ShowPrevious();
            _popupsManager.HideLast();
        }

        private void GiveReward()
        {
            Coins coins = new Coins {Amount = roundCoinsWonWatcher.Amount * attempt};
            _signalBus.Fire(new Won<Coins>(coins));
        }

        private void Reset()
        {
            //currentSum = 100;
            attempt = 0;
            history.Reset();
        }
    }
}
