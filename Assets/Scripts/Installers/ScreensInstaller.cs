using Core.GameScreens;
using Core.Popups;
using SlotsGame.Scripts.Effects;
using UnityEngine;
using Zenject;

public class ScreensInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log($"{nameof(ScreensInstaller)} Start InstallBindings -----------");
        
        Container.Bind<PopupsManager>().FromComponentInHierarchy().AsSingle();
        
        Container.Bind<ScreensManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EffectsManager>().FromComponentInHierarchy().AsSingle();
        
        Debug.Log($"{nameof(ScreensInstaller)} End InstallBindings -------------");
    }
}