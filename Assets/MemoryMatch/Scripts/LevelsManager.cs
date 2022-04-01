using System.Linq;
using GameCores.MemoryMatchGame;
using UnityEngine;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class LevelsManager
    {
        private const string CurrentLevelId = "CurrentLevelId";
        private const string MaxOpenedLevelId = "MaxOpenedLevelId";
        private const string LevelId = "level.";
        
        [Inject] private Levels _levels;
        public Level Current { get; private set; }
        public Level MaxOpened { get; private set; }

        public void Load()
        {
            LoadCurrent();
            LoadMaxOpened();
        }

        private void LoadMaxOpened()
        {
            var maxOpenedLevelId = PlayerPrefs.GetString(MaxOpenedLevelId, $"{LevelId}1");
            MaxOpened = _levels.GetObject(maxOpenedLevelId);
        }

        private void LoadCurrent()
        {
            var currentLevelId = PlayerPrefs.GetString(CurrentLevelId, $"{LevelId}1");
            SetCurrent(currentLevelId);
        }

        public void SetCurrent(int levelNum)
        {
            var level = _levels.All.First(l => l.Value.LevelNum.Equals(levelNum)).Value;
            Current = level;
        }
        
        public void SetCurrent(string levelId)
        {
            var level = _levels.All[levelId];
            Current = level;
        }

        public void TryOpenNextLevel()
        {
            int nextLevelNum = Current.LevelNum + 1;
            if (nextLevelNum > MaxOpened.LevelNum)
            {
                PlayerPrefs.SetString(MaxOpenedLevelId, $"{LevelId}{nextLevelNum}");
                LoadMaxOpened();
            }
        }

        public void TrySetNextLevelAsCurrent()
        {
            int nextLevelNum = Current.LevelNum + 1;
            if (nextLevelNum <= MaxOpened.LevelNum)
            {
                SetNextLevelAsCurrent();
            }
        }
        
        public void SetNextLevelAsCurrent()
        {
            int nextLevelNum = Current.LevelNum + 1;
            SetCurrent(nextLevelNum);
        }
    }
}