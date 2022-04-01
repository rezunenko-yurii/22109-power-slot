using Core.Finances.Store.Products;
using Core.Signals;
using Core.Signals.Base;
using Core.Signals.GameSignals;
using GameSignals;

namespace Core.Popups
{
    public class ProductPackReceivedPopup : InfoPopup
    {
        public override void HandleSignal(IGameSignal gameSignal)
        {
            base.HandleSignal(gameSignal);
            if (gameSignal is Taken<Bundle> received)
            {
                string text = PopupText(received.Target);
                SetText(text);
            }
        }
        
        private string PopupText(Bundle list)
        {
            string text = string.Empty;
            
            for (int i = 0; i < list.Products.Count; i++)
            {
                if (i != 0)
                {
                    text = $"{text} \n";
                }
                
                text = $"{text} {list.Products[i].Description}";
            }

            return text;
        }
    }
}