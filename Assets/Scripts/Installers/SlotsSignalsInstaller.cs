using Core.Signals.GameSignals;
using SlotsGame.Scripts;
using SlotsGame.Scripts.Bets;
using SlotsGame.Scripts.Slot;
using Zenject;

namespace Installers
{
    public class SlotsSignalsInstaller : MonoInstaller
    {
        [Inject] private SignalsHelper _signalsHelper;
        public override void InstallBindings()
        {
            _signalsHelper.DeclareSignal<BetSignals.Used>();
            
            _signalsHelper.DeclareSignal<Signal.Spin>();
            _signalsHelper.DeclareSignal<Signal.SpinOver>();
            
            _signalsHelper.DeclareSignal<SlotSignals.SpinStarted>();
            _signalsHelper.DeclareSignal<SlotSignals.SpinEnded>();
            _signalsHelper.DeclareSignal<SlotSignals.EffectsStarted>();
            _signalsHelper.DeclareSignal<SlotSignals.EffectsEnded>();
            _signalsHelper.DeclareSignal<SlotSignals.RoundEnded>();
        }
    }
}