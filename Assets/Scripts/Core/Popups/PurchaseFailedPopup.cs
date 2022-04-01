using Core.Finances.Store;
using Core.Signals;
using Core.Signals.Base;
using Core.Signals.GameSignals;
using GameSignals;

namespace Core.Popups
{
    public class PurchaseFailedPopup : InfoPopup
    {
        public override void HandleSignal(IGameSignal gameSignal)
        {
            base.HandleSignal(gameSignal);
            if (gameSignal is PurchaseFailed<Merchandise> failed)
            {
                SetText(failed.Target.ResultInfo);
            }
        }
    }
}