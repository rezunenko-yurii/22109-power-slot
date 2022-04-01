using System;
using Core.Messages;
using UnityEngine;
using Zenject;

namespace Bindings
{
    public class GameEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(GameEventsInstaller)} Start InstallBindings --------------");
            
            MessagesSystem system = new MessagesSystem();
            Container.Bind<MessagesSystem>().FromInstance(system).AsSingle();

            Debug.Log($"{nameof(GameEventsInstaller)} End InstallBindings --------------");
        }
    }
}