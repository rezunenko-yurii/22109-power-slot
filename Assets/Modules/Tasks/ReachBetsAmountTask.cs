using Core.Signals.GameSignals;
using SlotsGame.Scripts.Bets;
using Zenject;

namespace Modules.Tasks
{
    public class ReachBetsAmountTask : ReachAmountTask
    {
        [Inject] private SignalsHelper _signalsHelper;
        
        public override void StartObserving()
        {
            _signalsHelper.Subscribe<BetSignals.Used>(OnUsed);
        }

        public override void StopObserving()
        {
            _signalsHelper.Unsubscribe<BetSignals.Used>(OnUsed);
        }
        
        private void OnUsed(BetSignals.Used used)
        {
            OnProgressUpdated(used.Value);
        }
    }
}