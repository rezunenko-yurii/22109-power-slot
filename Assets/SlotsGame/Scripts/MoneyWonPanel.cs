using Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts
{
    public class MoneyWonPanel : AdvancedMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textField;
        [Inject] private RoundCoinsWonWatcher roundCoinsWonWatcher;
        private int _wonMoney;

        protected override void AddListeners()
        {
            roundCoinsWonWatcher.Changed += OnChanged;
        }

        private void OnChanged()
        {
            ChangeText(roundCoinsWonWatcher.Amount);
        }

        protected override void RemoveListeners()
        {
            roundCoinsWonWatcher.Changed += OnChanged;
        }
    
        private void ChangeText(float amount)
        {
            textField.text = amount.ToString();
        }
    }
}
