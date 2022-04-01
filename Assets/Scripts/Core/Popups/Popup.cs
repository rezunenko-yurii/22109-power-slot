using Core.Audio;
using Core.Signals;
using Core.Signals.Base;
using Core.Signals.GameSignals;
using UI;
using Zenject;

namespace Core.Popups
{
    public class Popup : UIObject, IPopup
    {
        [Inject] protected SoundsController _soundsController;
        
        public virtual void HandleSignal(IGameSignal gameSignal){}

    }
}