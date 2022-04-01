using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonus : MonoBehaviour
{
    public event Action Changed;
    [SerializeField] private Image image;
    public Image Skin => image;
    public Button Button;
    
    [SerializeField] private DailyBonusState emptyState;
    [SerializeField] private DailyBonusState lockedState;
    [SerializeField] private DailyBonusState nextToOpen;
    [SerializeField] private DailyBonusState readyState;
    [SerializeField] private DailyBonusState openedState;

    private DailyBonusState _currentState;
    public void SetState(DailyBonusStates states)
    {
        _currentState?.BeforeChanged();
        _currentState = states switch
        {
            DailyBonusStates.Empty => emptyState,
            DailyBonusStates.Locked => lockedState,
            DailyBonusStates.NextToOpen => nextToOpen,
            DailyBonusStates.Ready => readyState,
            DailyBonusStates.Opened => openedState,
            _ => throw new ArgumentOutOfRangeException(nameof(states), states, null)
        };

        _currentState.Context = this;
        _currentState.Apply();
    }
    
    /*private void SetStates(int day, int daysPassed)
    {
        if (day < i)
        {
            SetState(DailyBonusStates.Locked);
        }
        else if(day == i)
        {
            //int daysPassed = _bonusesManager.dateKeeper.DaysPassed();
           //Debug.Log($"daysPassed={daysPassed} lastDate={_bonusesManager.dateKeeper.Date} waitTime={_bonusesManager.timer.ExpireTimeSpan}");
            if (daysPassed >= 1)
            {
                SetState(DailyBonusStates.Ready);
            }
            else if (daysPassed == 0)
            {
                SetState(DailyBonusStates.NextToOpen);
            }
            /*else
            {
                _dailyBonuses[i].SetState(DailyBonusStates.Empty);
            }#1#
        }
        else if(day > i)
        {
            SetState(DailyBonusStates.Empty);
        }
    }*/

    public void OnChanged()
    {
        Changed?.Invoke();
    }
}
