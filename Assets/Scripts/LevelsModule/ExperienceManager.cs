using System;
using Core.Collectables;
using UnityEngine;
using Zenject;

namespace LevelsModule
{
    public class ExperienceManager
    {
        [Inject] private ExperienceLevels _experienceLevels;
        [Inject] private Scores _scores;
        
        public IntCollectableObject SavedLevel { get; protected set; } = new IntCollectableObject("experience level", 0);
        protected string LevelType { get; } = "experience";

        public ExperienceLevel Current { get; private set; }
        public void Init()
        {
            _scores.Added += OnScoresAdded;
            LoadLevel();
        }

        private void OnScoresAdded(int i)
        {
            if (_scores.Amount >= Current.Amount)
            {
                Increase();
            }
        }

        public int GetTotalScoresForNewLevel => Current.Amount;
        
        public int GetCurrentLevel()
        {
            return SavedLevel.Amount;
        }
        
        public event Action<int> Increased;

        protected void Increase()
        {
            Debug.Log($"{nameof(ExperienceManager)} {nameof(Increase)} to {SavedLevel.Amount + 1}");
            
            SavedLevel.Increase();
            _scores.Reset();

            LoadLevel();

            Increased?.Invoke(SavedLevel.Amount);
        }

        private void LoadLevel()
        {
            Current = _experienceLevels.GetObject(SavedLevel.Amount.ToString());
        }
    }
}