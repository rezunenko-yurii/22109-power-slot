using System;
using System.Collections.Generic;

namespace Core.Signals.GameSignals
{
    public class SignalsPool
    {
        private readonly Dictionary<Type, IGameSignal> _signals = new Dictionary<Type, IGameSignal>();
        
        public TSignal GetSignal<TSignal>()
        {
            return (TSignal) GetSignal(typeof(TSignal));
        }
        
        public IGameSignal GetSignal(Type signalType)
        {
            return _signals.ContainsKey(signalType) ? _signals[signalType] : AddSignal(signalType);
        }
        
        private IGameSignal AddSignal(Type signalType)
        {
            var signal = (IGameSignal) Activator.CreateInstance(signalType);
            _signals.Add(signalType, signal);

            return signal;
        }
    }
}