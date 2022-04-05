using Core.Signals.GameSignals;
using UnityEngine;
using Zenject;

namespace Core.Signals.Base
{
    public class EventSubscriber : AdvancedMonoBehaviour
    {
        [SerializeField] private string eventId;
        [Inject] private SignalEvents _signalEvents;

        private SignalEvent _signalEvent;

        protected override void Initialize()
        {
            base.Initialize();
            _signalEvent = _signalEvents.GetObject(eventId);
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            _signalEvent.Fired += OnFired;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _signalEvent.Fired -= OnFired;
        }

        private void OnFired(SignalEvent arg1, IGameSignal arg2)
        {
            
        }
    }
}