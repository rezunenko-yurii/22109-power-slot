using System.Collections.Generic;
using Core.Signals;
using Core.Signals.Base;
using Core.Signals.GameSignals;
using Zenject;

namespace Core.Popups.Showers
{
    public class PopupShower
    {
        [Inject] private PopupsManager _popupsManager;

        [Inject] private PopupShowerMaps _maps;
        [Inject] private SignalEvents _signalEvents;
        private List<SignalEvent> _subs;

        public void Init()
        {
            _subs = new List<SignalEvent>();
            foreach (var popupShowerMap in _maps.All)
            {
                var eventData = _signalEvents.GetObject(popupShowerMap.Value.EventId);
                eventData.Fired += TryShowPopup;
                _subs.Add(eventData);
            }
        }

        private void TryShowPopup(SignalEvent signalEvent, IGameSignal gameSignal)
        {
            foreach (var map in _maps.All)
            {
                if (map.Value.EventId.Equals(signalEvent.Id))
                {
                    var popup = _popupsManager.Get(map.Value.PopupId);
                    popup.HandleSignal(gameSignal);
                    _popupsManager.Show(popup);
                }
            }
        }
    }
}