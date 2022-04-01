using Zenject;

namespace Installers
{
    public class GameInstaller : AdvancedMonoInstaller
    {
        [Inject] private SignalBus _signalBus;

        public override void InstallBindings()
        {
            _signalBus.DeclareSignal<Core.GameSignals.Pause>();
            _signalBus.DeclareSignal<Core.GameSignals.Resume>();
            _signalBus.DeclareSignal<Core.GameSignals.Restart>();
            _signalBus.DeclareSignal<Core.GameSignals.NextLevel>();
            
            _signalBus.DeclareSignal<Core.GameSignals.UserInputPause>();
            _signalBus.DeclareSignal<Core.GameSignals.UserInputResume>();
        }
    }
}