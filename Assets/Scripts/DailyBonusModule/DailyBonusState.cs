using DefaultNamespace;
using UnityEngine;

public abstract class DailyBonusState : MonoBehaviour
{
    protected abstract DailyBonusStates State { get; }
    public DailyBonus Context { get; set; }

    public abstract void Apply();
    public abstract void BeforeChanged();
    public abstract bool CanApply(int itemDay, int currentDay, int passedDay);
}
