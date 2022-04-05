using Zenject;

namespace SlotsGame.Scripts
{
    public class SlotsManager
    {
        [Inject] private SpinPayer _spinPayer;
        [Inject] private SlotsGame _slotsGame;

        public void Spin()
        {
            if (CanPay)
            {
                //_spinPayer.PayForSpin();
                _slotsGame.StartRound();
            }
        }

        public bool CanPay => _spinPayer.CanPay();
    }
}