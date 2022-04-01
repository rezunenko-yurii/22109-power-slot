using GameCenter.Signals;
using UnityEngine;
using Zenject;

namespace GameCenter
{
    public class Achievements : GameCenterItem, IInitializable
    {
        public override void ShowBoard()
        {
            Social.ShowAchievementsUI();
        }

        protected override void Report(int value)
        {
            Social.ReportProgress(Application.identifier, value, ReportResult);
        }

        public void Initialize()
        {
            signalBus.Subscribe<ShowAchievements>(ShowBoard);
        }
    }
}