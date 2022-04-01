using Core.Audio;
using UnityEngine;
using Zenject;

namespace Bindings
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private SoundsCollection soundsCollection;
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(SoundsCollection)} Start InstallBindings --------------");
            
            Container.Bind<SoundsCollection>().FromInstance(soundsCollection).AsSingle();
        
            Container.Bind<SoundsController>().FromNewComponentOnNewGameObject().AsSingle().Lazy();
            Container.Bind<MusicController>().FromNewComponentOnNewGameObject().AsSingle().Lazy();
            
            Debug.Log($"{nameof(SoundsCollection)} End InstallBindings --------------");
        }
    }
}