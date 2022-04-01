using Core;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace DailyBonusModule
{
    public class DailyBonusesViewManager : AdvancedMonoBehaviour
    {
        [Inject] private DailyBonusesManager _bonusesManager;
        [SerializeField] private DailyBonus[] _dailyBonuses;
        
        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            SetStates();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            
            _bonusesManager.Timer.Over += OnTimerOver;
            foreach (var bonuse in _dailyBonuses)
            {
                bonuse.Changed += SetStates;
            }
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            _bonusesManager.Timer.Over -= OnTimerOver;
            foreach (var bonuse in _dailyBonuses)
            {
                bonuse.Changed -= SetStates;
            }
        }
        
        private void OnTimerOver()
        {
            SetStates();
        }

        private void SetStates()
        {
            /*for (int i = 0; i < _dailyBonuses.Length; i++)
            {
                Debug.Log($"CurrentDay={_bonusesManager.counter.CurrentDay}");
                
                if (_bonusesManager.counter.CurrentDay < i)
                {
                    _dailyBonuses[i].SetState(DailyBonusStates.Locked);
                }
                else if(_bonusesManager.counter.CurrentDay == i)
                {
                    int daysPassed = _bonusesManager.dateKeeper.DaysPassed();
                    Debug.Log($"daysPassed={daysPassed} lastDate={_bonusesManager.dateKeeper.Date} waitTime={_bonusesManager.timer.ExpireTimeSpan}");
                    if (daysPassed >= 1)
                    {
                        _dailyBonuses[i].SetState(DailyBonusStates.Ready);
                    }
                    else if (daysPassed == 0)
                    {
                        _dailyBonuses[i].SetState(DailyBonusStates.NextToOpen);
                    }
                    /*else
                    {
                        _dailyBonuses[i].SetState(DailyBonusStates.Empty);
                    }#1#
                }
                else if(_bonusesManager.counter.CurrentDay > i)
                {
                    _dailyBonuses[i].SetState(DailyBonusStates.Empty);
                }
            }*/
        }

        /*private void CreateItems()
        {
            _dailyBonuses = new DailyBonus[amount];
        
            for (int i = 0; i < amount; i++)
            {
                _dailyBonuses[i] = Instantiate(dailyBonusPrefab, transform, false);
            }
        }*/
    }
}
