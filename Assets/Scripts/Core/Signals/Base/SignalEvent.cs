using System;
using Core.Signals.GameSignals;

namespace Core.Signals.Base
{
    public class SignalEvent
    {
        public string Id { get; init; }
        public string TargetId { get; init; }
        public string TargetName { get; init; }
        public string SignalName { get; init; }
        
        public Action<SignalEvent, IGameSignal> Fired;
    }
}