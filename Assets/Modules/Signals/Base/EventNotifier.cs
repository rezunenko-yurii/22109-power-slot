using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Signals.GameSignals;
using Zenject;

namespace Core.Signals.Base 
{
    public class EventNotifier<TSignal, TTarget> : IInitializable 
        where TSignal : GameSignal<TTarget>
        where TTarget : IIdentifier
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private SignalEvents _signalEvents;

        private List<SignalEvent> _signalEventsList;
        
        public void Initialize()
        {
            _signalBus.Subscribe<TSignal>(OnReceived);
            
            var type = typeof(TSignal);
            var signalType = type.Name.Remove(type.Name.IndexOf('`'));
            var fields = type.GetTypeInfo().GenericTypeArguments;
            var signalTargetType = fields.First().Name;
            
            _signalEventsList = _signalEvents.GetObjects(signalType, signalTargetType);
        }

        protected virtual void OnReceived(TSignal signal)
        {
            var targetId = signal.Target.Id;
            
            foreach (var eventData in _signalEventsList)
            {
                if (targetId.Equals(eventData.TargetId))
                {
                    eventData.Fired?.Invoke(eventData, signal);
                    break;
                }
            }
        }
    }
}