using Core.Signals.Implementation.Providers;
using DefaultNamespace;
using Finances.Store;
using Zenject;

namespace Installers
{
    public class ProductProvidersInstaller : AdvancedMonoInstaller
    {
        public override void InstallBindings()
        {
            Create<CoinsProvider>();
            Create<SpinsProvider>();
            Create<LevelProvider>();
            Create<BundleProvider>();
            Create<MerchandiseProvider>();
        }
    }
}