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
            Container.Bind<SignalEvents>().FromInstance(datas).AsSingle();
            
            Container.Bind<Moneys>().AsSingle().NonLazy();
            Container.Bind<Products>().AsSingle().OnInstantiated<Products>((_, products) => products.Init(productConfig)).NonLazy();

            var productPackProvider = Container.Instantiate<Bundles>();
            productPackProvider.Init(productPackConfig);
            Container.Bind<Bundles>().FromInstance(productPackProvider).NonLazy();
            
            var productPacksProvider = Container.Instantiate<ProductBundlesSets>();
            productPacksProvider.Init(productPacksConfig);
            Container.Bind<ProductBundlesSets>().FromInstance(productPacksProvider).NonLazy();
            
            Merchandises merchandises = Container.Instantiate<Merchandises>();
            merchandises.Init(merchandisesConfig);
            Container.Bind<Merchandises>().FromInstance(merchandises).NonLazy();
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