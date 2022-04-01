using Core.Finances.Store;
using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using Installers;
using Zenject;

namespace Finances.Store
{
    public class MerchandiseProvider : IPreInitializable
    {
        [Inject] private SignalsHelper _signalsHelper;
        
        private void Handle(Purchased<Merchandise> obj)
        {
            _signalsHelper.Fire(typeof(Purchased<Bundle>), obj.Target.Bundle);
            _signalsHelper.Fire(typeof(Taken<Merchandise>), obj.Target);
        }

        public void PreInitialize()
        {
            _signalsHelper.DeclareSignal<Taken<Merchandise>>();
            _signalsHelper.Declare<Purchased<Merchandise>, Merchandise>(Handle);
        }
    }
}