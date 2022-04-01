using Zenject;

namespace SlotsGame.Scripts
{
    public class SlotsManager
    {
        [Inject] private SpinPayer _spinPayer;
        [Inject] private SlotsGame _slotsGame;

        public void Spin()
        {
            if (_spinPayer.CanPay())
            {
                _spinPayer.PayForSpin();
                _slotsGame.StartRound();
            }
        }
    }
}