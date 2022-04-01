using LevelsModule;
using UnityEngine;
using Zenject;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    public class ScoresProgressChecker : ImageSpriteSwitcher
    {
        [Inject] private ExperienceManager _manager;
        [Inject] private Scores _scores;
        [SerializeField, Range(0f, 100f)] private float percent;
        
        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            Check(_scores.Amount);
        }
        
        protected override void AddListeners()
        {
            base.AddListeners();
            _scores.Changed += Check;
        }
        
        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _scores.Changed -= Check;
        }

        private void Check(int obj)
        {
            float currPercent = HowManyPercentIsOneNumberFromAnother(obj,
                _manager.GetTotalScoresForNewLevel);
            if (currPercent >= percent)
            {
                Input(true);
            }
            else
            {
                Input(false);
            }
        }
        
        public int HowManyPercentIsOneNumberFromAnother(int number, int fromNumber)
        {
            float a = (float) number / fromNumber;
            int b = (int) (a * 100f);
            
            return b;
        }
    }
}