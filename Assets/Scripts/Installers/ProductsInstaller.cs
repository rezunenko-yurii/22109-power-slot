using Core.Finances;
using Core.Finances.Moneys;
using Core.Finances.Store.Products;
using Core.Signals.Base;
using Core.Signals.GameSignals;
using Finances.Moneys;
using UnityEngine;
using WalletsImp;
using Zenject;

namespace Installers
{
    public class ProductsInstaller : MonoInstaller
    {
        [Inject] private SignalsHelper _signalsHelper;
        
        [SerializeField] private TextAsset productConfig;
        [SerializeField] private TextAsset productPackConfig;
        [SerializeField] private TextAsset productPacksConfig;
        [SerializeField] private TextAsset merchandisesConfig;
        [SerializeField] private TextAsset subscribersConfig;
        public override void InstallBindings()
        {
            InstallSignals();
            
            SignalEvents datas = new SignalEvents();
            datas.Init(subscribersConfig);
            _signalsHelper.Container.Bind<SignalEvents>().FromInstance(datas).AsSingle();
            
            _signalsHelper.Container.Bind<Moneys>().AsSingle().NonLazy();
            _signalsHelper.Container.Bind<Products>().AsSingle().OnInstantiated<Products>((_, products) => products.Init(productConfig)).NonLazy();

            var bundles = Container.Instantiate<Bundles>();
            bundles.Init(productPackConfig);
            _signalsHelper.Container.Bind<Bundles>().FromInstance(bundles).NonLazy();
            
            var bundlesSets = Container.Instantiate<ProductBundlesSets>();
            bundlesSets.Init(productPacksConfig);
            _signalsHelper.Container.Bind<ProductBundlesSets>().FromInstance(bundlesSets).NonLazy();
            
            Merchandises merchandises = Container.Instantiate<Merchandises>();
            merchandises.Init(merchandisesConfig);
            _signalsHelper.Container.Bind<Merchandises>().FromInstance(merchandises).NonLazy();
        }
        
        private void InstallSignals()
        {
            //Container.DeclareSignal<PurchaseFailed<IProduct>>();
            //Container.DeclareSignal<PurchaseFailed<Bundle>>();
            //Container.DeclareSignal<PurchaseFailed<Merchandise>>();
            
            
            _signalsHelper.DeclareSignal<MoneySignals.Added<Coins>>();
            _signalsHelper.DeclareSignal<MoneySignals.Subtracted<Coins>>();
            _signalsHelper.DeclareSignal<MoneySignals.Changed<Coins>>();
            
            _signalsHelper.DeclareSignal<MoneySignals.Added<Spins>>();
            _signalsHelper.DeclareSignal<MoneySignals.Subtracted<Spins>>();
            _signalsHelper.DeclareSignal<MoneySignals.Changed<Spins>>();
            
            _signalsHelper.DeclareSignal<SpinsSignals.Spent>();
        }
    }
}