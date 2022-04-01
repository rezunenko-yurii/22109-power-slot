using UnityEngine;
using Zenject;

namespace Installers
{
    public class AdvancedMonoInstaller : MonoInstaller
    {
        [SerializeField] protected bool use;
        
        protected void Create<T>() where T : IPreInitializable
        {
            var t = Container.Instantiate<T>();
            t.PreInitialize();
            Container.Bind<T>().FromInstance(t).AsSingle();
        }
    }
}