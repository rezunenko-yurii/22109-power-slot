using Core.Finances.Store.Products;
using Core.Signals.Base;
using Core.Signals.GameSignals;
using Installers;
using Zenject;

namespace Core.Signals.Implementation.Providers
{
    public abstract class ProductProvider<TSignalTarget> : IPreInitializable, IWonProvider<TSignalTarget>, ITPurchasedProvider<TSignalTarget>
        where TSignalTarget : class, IProduct
    {
        [Inject] protected SignalsHelper SignalsHelper;
        
        public void PreInitialize()
        {
            SignalsHelper.DeclareSignal<Taken<TSignalTarget>>();
            SignalsHelper.CreateEventNotifier<Taken<TSignalTarget>, TSignalTarget>();
            
            SignalsHelper.Declare<Purchased<TSignalTarget>,TSignalTarget>(Handle);
            SignalsHelper.Declare<Won<TSignalTarget>,TSignalTarget>(Handle);
        }
        
        public abstract void Handle(TSignalTarget target);
        
        public virtual void Handle(Won<TSignalTarget> won)
        {
            Handle(won.Target);
            FireTaken(won.Target);
        }
        
        public virtual void Handle(Purchased<TSignalTarget> purchased)
        {
            Handle(purchased.Target);
            FireTaken(purchased.Target);
        }
        
        private void FireTaken(TSignalTarget target)
        {
            SignalsHelper.Fire(typeof(Taken<TSignalTarget>), target);
        }
    }
}