using System;
using System.Collections.Generic;
using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using Installers;
using Zenject;

namespace Core.Signals.Implementation.Providers
{
    public class BundleProvider : IPreInitializable
    {
        [Inject] private SignalsHelper _signalsHelper;
        
        public void PreInitialize()
        {
            _signalsHelper.DeclareSignal<Taken<Bundle>>();
            _signalsHelper.CreateEventNotifier<Taken<Bundle>, Bundle>();
            
            _signalsHelper.Declare<Purchased<Bundle>,Bundle>(Handle);
            _signalsHelper.Declare<Won<Bundle>, Bundle>(Handle);
        }
        
        private void Handle(Purchased<Bundle> obj)
        {
            FireNext(typeof(Purchased<>), obj.Target.Products);
            _signalsHelper.Fire(typeof(Taken<Bundle>),obj.Target);
        }

        private void Handle(Won<Bundle> obj)
        {
            FireNext(typeof(Won<>), obj.Target.Products);
            _signalsHelper.Fire(typeof(Taken<Bundle>),obj.Target);
        }

        private void FireNext(Type signalType, IEnumerable<IProduct> products)
        {
            foreach (var product in products)
            {
                var productType = product.GetType();
                var genericType = signalType.MakeGenericType(productType);
       
                _signalsHelper.Fire(genericType, product);
            }
        }
    }
}