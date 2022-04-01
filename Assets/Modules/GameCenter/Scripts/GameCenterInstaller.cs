using GameCenter.Signals;
using UnityEngine;
using Zenject;

namespace GameCenter
{
    public class GameCenterInstaller : MonoInstaller
    {
        [SerializeField] private bool useLeaderBoard;
        [SerializeField] private bool useAchievements;
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(GameCenterInstaller)} Start InstallBindings -------------");
            
            Container.Bind<Login>().AsSingle().NonLazy();
            
            if (useLeaderBoard)
            {
                Container.BindInterfacesAndSelfTo<Leaderboard>().AsSingle().NonLazy();
                Container.DeclareSignal<ShowLeaderboard>();
            }

            if (useAchievements)
            {
                Container.BindInterfacesAndSelfTo<Achievements>().AsSingle().NonLazy();
                Container.DeclareSignal<ShowAchievements>();
            }
            
            Debug.Log($"{nameof(GameCenterInstaller)} End InstallBindings -------------");
        }
    }
}