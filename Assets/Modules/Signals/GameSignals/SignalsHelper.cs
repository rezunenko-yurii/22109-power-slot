using System;
using Core.Signals.Base;
using Zenject;

namespace Core.Signals.GameSignals
{
    public class SignalsHelper
    {
        [Inject] protected SignalBus SignalBus;
        [Inject] public DiContainer Container { get; }

        private SignalsPool Pool => new SignalsPool();

        public void DeclareSignal<TSignal>() => SignalBus.DeclareSignal<TSignal>();

        public void Declare<TSignal, TTarget>(Action<TSignal> handle) 
            where TSignal : GameSignal<TTarget>
            where TTarget : IIdentifier
        {
            DeclareSignal<TSignal>();
            SignalBus.Subscribe(handle);
            CreateEventNotifier<TSignal, TTarget>();
        }

        public void Subscribe<TSignal>(Action<TSignal> action)
        {
            SignalBus.Subscribe<TSignal>(action);
        }
        
        public void Unsubscribe<TSignal>(Action<TSignal> action)
        {
            SignalBus.Unsubscribe<TSignal>(action);
        }

        public void CreateEventNotifier<TSignal, TTarget>() 
            where TSignal : GameSignal<TTarget> 
            where TTarget : IIdentifier
        {
            var e = Container.Instantiate<EventNotifier<TSignal, TTarget>>();
            e.Initialize();
            Container.Bind<EventNotifier<TSignal, TTarget>>().FromInstance(e).AsSingle();
        }

        public void Fire(Type signalType, IIdentifier target)
        {
            var signal = Pool.GetSignal(signalType);
            Fire(signal as GameSignal, target);
        }
        
        public void Fire<TSignal>()
        {
            var signal = Pool.GetSignal<TSignal>();
            Fire(signal as IGameSignal);
        }

        public void Fire(GameSignal signal, IIdentifier target)
        {
            signal.Target = target;
            Fire(signal);
        }
        
        public void Fire(IGameSignal signal)
        {
            SignalBus.Fire(signal as object);
        }
    }
}