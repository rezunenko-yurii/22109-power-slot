using Core.Collectables;
using Core.Finances.Moneys;
using Core.Moneys;
using UnityEngine;
using Zenject;

namespace Core.Finances.Wallets
{
    public abstract class Wallet<T> : IWallet where T: class, IMoney
    {
        [Inject] private SignalBus _signalBus;

        protected ICollectableObject<float> Collectable;

        public Wallet(ICollectableObject<float> collectableObject)
        {
            Collectable = collectableObject;
        }

        public float Balance() => Collectable.Amount;

        public void Add(IMoney amount) => Add(amount as T);

        public void Subtract(IMoney money) => Subtract(money as T);

        private void Add(T moneyToAdd)
        {
            Debug.Log($"{nameof(Wallet<T>)} {nameof(Add)} {moneyToAdd}");

            if (moneyToAdd.Amount > 0)
            {
                Collectable.Increase(moneyToAdd.Amount);

                FireAddedSignal(moneyToAdd.Amount);
                FireChangedSignal(Collectable.Amount);
            }
        }
        
        public void Subtract(T moneyToSubtract)
        {
            Debug.Log($"{nameof(Wallet<T>)} {nameof(Subtract)} {moneyToSubtract}");
            Subtract(moneyToSubtract.Amount);
        }

        public void Subtract(float amount)
        {
            if (CanSubtract(amount))
            {
                Collectable.Decrease(amount);
                
                FireChangedSignal(Collectable.Amount);
                FireSpentSignal(amount); 
            }
        }
        
        public bool CanSubtract(IMoney money) => CanSubtract(money.Amount);
        public bool CanSubtract(float amount) => (Collectable.Amount - amount) >= 0;
        public bool HasOnBalance(IMoney money) => HasOnBalance(money.Amount);
        public bool HasOnBalance(float amount) => Collectable.Amount >= amount;

        public abstract bool CanDecreaseInMinus { get; protected set; }
        
        public void Reset()
        {
            Debug.Log($"{nameof(Wallet<T>)} {nameof(Reset)}");
            Collectable.Reset();
        }
        
        private void FireChangedSignal(float value)
        {
            _signalBus.Fire(new MoneySignals.Changed<T>(value));
        }
        private void FireAddedSignal(float value)
        {
            _signalBus.Fire(new MoneySignals.Added<T>(value));
        }
        private void FireSpentSignal(float value)
        {
            _signalBus.Fire(new MoneySignals.Subtracted<T>(value));
        }
    }
}