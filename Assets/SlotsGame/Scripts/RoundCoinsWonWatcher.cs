using System;
using Core.Finances.Moneys;
using Zenject;

namespace SlotsGame.Scripts
{
    public class RoundCoinsWonWatcher
    {
        public event Action Changed;
        public float Amount { get; private set; }

        [Inject] private SignalBus _signalBus;
        
        public void Init()
        {
            _signalBus.Subscribe<MoneySignals.Added<Coins>>(OnAdded);
            _signalBus.Subscribe<SlotSignals.SpinStarted>(Reset);
        }

        private void Reset()
        {
            OnChanged(0);
        }

        private void OnAdded(MoneySignals.Added<Coins> obj)
        {
            OnChanged(Amount += obj.Value);
        }

        private void OnChanged(float amount)
        {
            Amount = amount;
            Changed?.Invoke();
        }
    }
}