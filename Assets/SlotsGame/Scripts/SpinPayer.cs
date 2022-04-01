using Core.Finances.Wallets;
using Finances.Wallets;
using SlotsGame.Scripts.Bets;
using SlotsGame.Scripts.Lines;
using Zenject;

namespace SlotsGame.Scripts
{
    public class SpinPayer
    {
        [Inject] private BetsManager _betsManager;
        [Inject] private LinesManager _linesManager;
        [Inject] private CoinsWallet _coinsWallet;
        [Inject] private SpinsWallet _spinsWallet;
        
        public int SpinCostInCoins()
        {
            return _betsManager.Current * _linesManager.GetActiveLinesAmount();
        }
        
        public bool CanPayByCoins()
        {
            return _coinsWallet.HasOnBalance(SpinCostInCoins());
        }
        
        public bool CanPayByFreeSpins()
        {
            return _spinsWallet.HasOnBalance(1);
        }

        public bool CanPay()
        {
            return CanPayByFreeSpins() || CanPayByCoins();
        }

        private void PayByCoins()
        {
            var cost = SpinCostInCoins();
            _coinsWallet.Subtract(cost);
        }

        private void PayByFreeSpins()
        {
            _spinsWallet.Subtract(1);
        }
        
        public void Spin()
        { 
            if (CanPay())
            {
                PayForSpin();
            }
            /*else
            {
                _autoSpin.TransitionTo(AutoSpinType.Off);
            }*/
        }
        
        public void PayForSpin()
        {
            if (CanPayByFreeSpins())
            {
                PayByFreeSpins();
            }
            else if (CanPayByCoins())
            {
                PayByCoins();
            }
        }
    }
}