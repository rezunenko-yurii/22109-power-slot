using GameCenter.Signals;
using UnityEngine;
using Zenject;

namespace GameCenter
{
    public class Leaderboard : GameCenterItem, IInitializable
    {
        public override void ShowBoard()
        {
            Social.ShowLeaderboardUI();
        }

        protected override void Report(int value)
        {
            Social.ReportScore(value, Application.identifier, ReportResult);
        }

        public void Initialize()
        {
            signalBus.Subscribe<ShowLeaderboard>(ShowBoard);
        }
    }
}