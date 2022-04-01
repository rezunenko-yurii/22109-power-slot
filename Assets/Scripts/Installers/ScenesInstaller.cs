using Core.GameScreens;
using Core.Popups;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ScenesInstaller : MonoInstaller
    {
        [SerializeField] private TextAsset scenesConfig;
        [SerializeField] private TextAsset screensConfig;
        [SerializeField] private TextAsset popupsConfig;
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(ScenesInstaller)} Start InstallBindings --------------");

            SignalBusInstaller.Install(Container);
            
            var scenes = Container.Instantiate<UI.Scenes>();
            scenes.Init(scenesConfig);
            Container.Bind<UI.Scenes>().FromInstance(scenes).AsSingle();

            var gameScreens = Container.Instantiate<GameScreens>();
            gameScreens.Init(screensConfig);
            Container.Bind<GameScreens>().FromInstance(gameScreens).AsSingle();

            var popups = Container.Instantiate<Popups>();
            popups.Init(popupsConfig);
            Container.Bind<Popups>().FromInstance(popups).AsSingle();
            
            Debug.Log($"{nameof(ScenesInstaller)} Start InstallBindings --------------");
        }
    }
}