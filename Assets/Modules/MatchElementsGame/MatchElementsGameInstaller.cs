using MatchGame;
using UnityEngine;
using Zenject;

namespace GameCores.MatchElementsGame
{
    public class MatchElementsGameInstaller : MonoInstaller
    {
        [Inject] private SignalBus signalBus;
        [SerializeField] private TextAsset levelsConfig;
        
        public override void InstallBindings()
        {
            signalBus.DeclareSignal<MatchSignals.MatchBoosterSignal>();
            signalBus.DeclareSignal<MatchSignals.Restart>();
            
            MatchLevels matchLevels = new MatchLevels();
            matchLevels.Init(levelsConfig);
            Container.Bind<MatchLevels>().FromInstance(matchLevels).AsSingle();
            
            MatchBoostersList boostersList = new MatchBoostersList();
            boostersList.Names.Add("shuffle");
            Container.Bind<MatchBoostersList>().FromInstance(boostersList).AsSingle();
        }
    }
}