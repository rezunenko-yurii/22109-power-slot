using DefaultNamespace;
using UnityEngine;

public class DailyBonusLockedState : DailyBonusState
{
    [SerializeField] private Sprite sprite;
    protected override DailyBonusStates State { get; } = DailyBonusStates.Locked;
    public override void Apply()
    {
        Context.Skin.sprite = sprite;
    }

    public override void BeforeChanged()
    {
        //throw new System.NotImplementedException();
    }

    public override bool CanApply(int itemDay, int currentDay, int passedDay)
    {
        return currentDay < itemDay;
    }
}
